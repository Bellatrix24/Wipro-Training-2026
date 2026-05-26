using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Day26RepositoryPatternSecurity.Controllers
{
    // Hey diary! This is our secure StudentController.
    // Instead of instantiating the database context directly, we inject the IStudentRepository interface.
    // This scoped registration tells our app to reuse one repository instance per web request, keeping things clean!
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repository;

        // Constructor injection of our Repository Interface.
        // This decouples the presentation controller logic from the Entity Framework infrastructure!
        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        // GET: /Student/
        // Fetches all student records and sends them down to populate our presentation view.
        public IActionResult Index()
        {
            var students = _repository.GetAllStudents();
            return View(students);
        }

        // POST: /Student/Create
        // Receives submitted student details and saves them safely to Wipro student database.
        [HttpPost]
        [ValidateAntiForgeryToken] // Stops Cross-Site Request Forgery (CSRF) session hijackings!
        public IActionResult Create(Student student)
        {
            // Verify that the model inputs match our key validation constraint attributes
            if (ModelState.IsValid)
            {
                _repository.AddStudent(student);
                _repository.Save();
                
                // Redirect cleanly back to the overview table page once saved!
                return RedirectToAction(nameof(Index));
            }
            
            // If inputs are bad, re-render the submission view so the user can fix errors.
            return View(student);
        }
    }
}

/*
@* ----------------------------------------------------------------------------- *@
@* Razor View snippet: Index.cshtml                                              *@
@* Place this inside Views/Student/Index.cshtml                                  *@
@* ----------------------------------------------------------------------------- *@

@model IEnumerable<Day26RepositoryPatternSecurity.Student>

@{
    ViewData["Title"] = "Student Overview Lab";
}

<div class="container" style="margin-top: 20px; font-family: sans-serif;">
    <h2>Wipro Trainee Student Database Overview</h2>

    <table class="table" style="width: 100%; border-collapse: collapse; margin-top: 15px;">
        <thead>
            <tr style="background-color: #f2f2f2; border-bottom: 2px solid #ccc; text-align: left;">
                <th style="padding: 10px;">Student ID</th>
                <th style="padding: 10px;">Name</th>
                <th style="padding: 10px;">Course</th>
                <th style="padding: 10px;">Age</th>
            </tr>
        </thead>
        <tbody>
            @* Hey diary! We loop through the collection using @foreach to write rows cleanly *@
            @foreach (var student in Model)
            {
                <tr style="border-bottom: 1px solid #ddd;">
                    <td style="padding: 10px;">@student.StudentId</td>
                    <td style="padding: 10px;">@student.Name</td>
                    <td style="padding: 10px;">@student.Course</td>
                    <td style="padding: 10px;">@student.Age</td>
                </tr>
            }
        </tbody>
    </table>
</div>
*/
