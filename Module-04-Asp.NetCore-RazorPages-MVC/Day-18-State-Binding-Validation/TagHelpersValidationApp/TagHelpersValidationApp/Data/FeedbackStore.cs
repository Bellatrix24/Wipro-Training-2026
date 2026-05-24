using System.Collections.Generic;
using TagHelpersValidationApp.Models;

namespace TagHelpersValidationApp.Data
{
    // Natural comment: Static store to act as an in-memory database for submitted feedback.
    public static class FeedbackStore
    {
        public static List<Feedback> Feedbacks { get; set; } = new List<Feedback>
        {
            new Feedback 
            { 
                Name = "Alice Williams", 
                Email = "alice.w@example.com", 
                Rating = 5, 
                Comments = "Awesome training projects! The tag helper star widget looks beautiful." 
            },
            new Feedback 
            { 
                Name = "Bob Jones", 
                Email = "bob.jones@example.com", 
                Rating = 4, 
                Comments = "Very clean validation pipelines. Works smoothly in modern .NET." 
            }
        };
    }
}
