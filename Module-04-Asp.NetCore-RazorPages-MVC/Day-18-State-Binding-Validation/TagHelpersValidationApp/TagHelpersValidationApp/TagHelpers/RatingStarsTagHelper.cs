using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpersValidationApp.TagHelpers
{
    // Natural comment: Custom Tag Helper to render rating stars widget using HTML entities instead of raw emojis.
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
                    // Render filled star entity (yellow)
                    sb.Append("<span style='color: #ffc107; font-size: 1.4em;'>&#9733;</span>");
                }
                else
                {
                    // Render empty star entity (gray)
                    sb.Append("<span style='color: #d1d1d1; font-size: 1.4em;'>&#9734;</span>");
                }
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
