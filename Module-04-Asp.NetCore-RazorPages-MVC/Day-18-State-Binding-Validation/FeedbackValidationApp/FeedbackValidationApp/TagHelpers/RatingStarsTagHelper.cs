using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FeedbackValidationApp.TagHelpers
{
    // Natural comment: Custom Tag Helper to render rating stars widget using HTML span elements.
    [HtmlTargetElement("rating-stars")]
    public class RatingStarsTagHelper : TagHelper
    {
        [HtmlAttributeName("rating")]
        public int Rating { get; set; }

        [HtmlAttributeName("max-stars")]
        public int MaxStars { get; set; } = 5;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.Attributes.SetAttribute("class", "rating-stars-container");

            var sb = new StringBuilder();
            for (int i = 1; i <= MaxStars; i++)
            {
                if (i <= Rating)
                {
                    // Render yellow filled star
                    sb.Append("<span style='color: #ffc107; font-size: 1.4em;'>★</span>");
                }
                else
                {
                    // Render gray empty star
                    sb.Append("<span style='color: #d1d1d1; font-size: 1.4em;'>☆</span>");
                }
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
