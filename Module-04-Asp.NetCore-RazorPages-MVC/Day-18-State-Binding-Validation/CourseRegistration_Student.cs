using System.ComponentModel.DataAnnotations;

namespace WiproTraining.Day18.Models
{
    // This is our simple model class representing a student registering for a course
    public class CourseRegistration_Student
    {
        // Simple property for the student's full name
        [Required(ErrorMessage = "Student name is required!")]
        public string Name { get; set; }

        // Property for the student's email address with automatic format checking
        [Required(ErrorMessage = "Email address is required!")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        public string Email { get; set; }

        // Property for the student's age, restricted to our standard training program ranges
        [Required(ErrorMessage = "Age is required!")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60!")]
        public int Age { get; set; }
    }
}
