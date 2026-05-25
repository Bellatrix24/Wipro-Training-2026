using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureDatabaseSecurityPortal.Data;
using SecureDatabaseSecurityPortal.Models;
using SecureDatabaseSecurityPortal.Services;

namespace SecureDatabaseSecurityPortal.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HmacService _hmacService;
        private readonly AuditService _auditService;

        public ProfileController(
            ApplicationDbContext context,
            HmacService hmacService,
            AuditService auditService)
        {
            _context = context;
            _hmacService = hmacService;
            _auditService = auditService;
        }

        public async Task<IActionResult> SecureRecords()
        {
            var records = await _context.CustomerRecords.AsNoTracking().ToListAsync();
            var modelList = new List<CustomerRecordViewModel>();

            foreach (var r in records)
            {
                // 1. AES Decrypt the TaxId
                var decryptedTaxId = _hmacService.Decrypt(r.EncryptedTaxId);

                // 2. Verify SHA256 HMAC integrity checksum to detect tampering
                var isValid = _hmacService.VerifyHmac(decryptedTaxId, r.TaxIdHmac);

                if (!isValid)
                {
                    // Audit high-risk database tampering attempt
                    await _auditService.LogActionAsync(
                        User.Identity?.Name ?? "System",
                        "Data Tampering Detected",
                        $"Cryptographic signature verification failed for Customer Record ID: {r.RecordId}.",
                        isSuspicious: true
                    );
                }

                modelList.Add(new CustomerRecordViewModel
                {
                    RecordId = r.RecordId,
                    FullName = r.FullName,
                    Email = r.Email,
                    PhoneNumber = r.PhoneNumber,
                    TaxId = isValid ? decryptedTaxId : "[WARNING: CRYPTOGRAPHIC SIGNATURE MISMATCH / DATABASE TAMPERED!]",
                    IsTampered = !isValid
                });
            }

            return View(modelList);
        }
    }

    public class CustomerRecordViewModel
    {
        public int RecordId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public bool IsTampered { get; set; }
    }
}
