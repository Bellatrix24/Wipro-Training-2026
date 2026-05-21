using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WiproTraining.Day20.Controllers
{
    // This controller manages hospital login states and patient cookie configurations
    public class AccountController : Controller
    {
        // POST handler that sets our patient's session token upon successful login
        [HttpPost]
        public IActionResult Login(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index");
            }

            // We store the username securely inside the server session RAM.
            // Storing the patient ID so we don't forget who is logged in!
            HttpContext.Session.SetString("UserName", username);

            return RedirectToAction("Dashboard");
        }

        // Simple dashboard pathway showing the logged-in user
        public IActionResult Dashboard()
        {
            string patient = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(patient))
            {
                return Content("Access Denied: Please log in first.");
            }

            return Content($"Welcome back, patient: {patient}!");
        }

        // Sets a client-side preference cookie in the browser
        public IActionResult SetPreference(string lang)
        {
            if (string.IsNullOrEmpty(lang))
            {
                lang = "English";
            }

            // CookieOptions allow us to configure how long the browser remembers this cookie!
            CookieOptions options = new CookieOptions
            {
                // Cookies persist on the browser even after the server restarts or the session expires!
                // We set an explicit expiration of 7 days so it stays saved long-term.
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true // Enhances safety by keeping client JavaScript from tampering with it
            };

            // Appends the language cookie to our HTTP Response header
            Response.Cookies.Append("UserLanguage", lang, options);

            return Content($"Saved patient language preference: '{lang}' in cookie storage!");
        }

        // Reads the client-side preference cookie back from the browser
        public IActionResult GetPreference()
        {
            // We fetch the cookie value securely from the incoming HTTP Request headers
            string preferredLang = Request.Cookies["UserLanguage"];

            if (string.IsNullOrEmpty(preferredLang))
            {
                preferredLang = "None set (using standard English fallback)";
            }

            return Content($"Retrieved language preference from cookie: {preferredLang}");
        }
    }
}
