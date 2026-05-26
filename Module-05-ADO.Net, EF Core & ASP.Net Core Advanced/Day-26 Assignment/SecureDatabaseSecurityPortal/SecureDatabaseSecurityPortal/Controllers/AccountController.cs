using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureDatabaseSecurityPortal.Models;
using SecureDatabaseSecurityPortal.Services;
using SecureDatabaseSecurityPortal.ViewModels;

namespace SecureDatabaseSecurityPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AuditService _auditService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            AuditService auditService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _auditService = auditService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Registering users get the regular "User" role by default
                await _userManager.AddToRoleAsync(user, "User");
                
                await _auditService.LogActionAsync(user.Email, "User Registration", "New account registered successfully.", isSuspicious: false);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Lockout on failure is true to mitigate brute force attempts
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                await _auditService.LogActionAsync(model.Email, "User Login", "User authenticated successfully.", isSuspicious: false);
                if (!string.IsNullOrWhiteSpace(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }

            if (result.IsLockedOut)
            {
                // Audits suspicious brute-force activity
                await _auditService.LogActionAsync(model.Email, "Login Blocked", "Brute-force activity triggered account lockout.", isSuspicious: true);
                ModelState.AddModelError(string.Empty, "This account is locked due to too many failed attempts. Try again in 5 minutes.");
                return View(model);
            }

            // Logs suspicious access attempt
            await _auditService.LogActionAsync(model.Email, "Login Failure", "Failed login attempt: invalid credentials.", isSuspicious: true);

            // Authentication latency delay
            await Task.Delay(1000);

            ModelState.AddModelError(string.Empty, "Invalid login credentials.");
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            var email = User.Identity?.Name;
            await _signInManager.SignOutAsync();
            
            // Clear session data
            HttpContext.Session.Clear();
            
            // Clear identity and session cookies
            Response.Cookies.Delete(".AspNetCore.Identity.Application");
            Response.Cookies.Delete(".AspNetCore.Session");

            if (!string.IsNullOrEmpty(email))
            {
                await _auditService.LogActionAsync(email, "User Logout", "User logged out securely.", isSuspicious: false);
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
