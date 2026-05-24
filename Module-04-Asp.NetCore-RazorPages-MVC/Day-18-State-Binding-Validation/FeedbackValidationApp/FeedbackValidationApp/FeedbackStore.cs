using System.Collections.Generic;
using FeedbackValidationApp.Models;

namespace FeedbackValidationApp
{
    // Natural comment: Static in-memory database to store submitted feedback.
    public static class FeedbackStore
    {
        public static List<Feedback> Feedbacks { get; set; } = new List<Feedback>
        {
            new Feedback 
            { 
                Name = "John Doe", 
                Email = "john.doe@example.com", 
                Rating = 5, 
                Comments = "Excellent training materials! Everything was explained very clearly." 
            },
            new Feedback 
            { 
                Name = "Jane Smith", 
                Email = "jane.smith@example.com", 
                Rating = 4, 
                Comments = "Good assignment exercises. The custom rating tag helper is very neat." 
            }
        };
    }
}
