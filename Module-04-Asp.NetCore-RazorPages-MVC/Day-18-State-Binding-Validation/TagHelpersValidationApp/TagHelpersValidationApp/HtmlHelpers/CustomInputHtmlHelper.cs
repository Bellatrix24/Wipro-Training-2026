using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TagHelpersValidationApp.HtmlHelpers
{
    // Natural comment: Extension class to create a custom HTML Helper for styled input fields.
    public static class CustomInputHtmlHelper
    {
        public static IHtmlContent CustomInput(this IHtmlHelper htmlHelper, string name, string value, string placeholder, string cssClass)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes.Add("type", "text");
            tagBuilder.Attributes.Add("name", name);
            tagBuilder.Attributes.Add("id", name);
            tagBuilder.Attributes.Add("value", value ?? string.Empty);
            tagBuilder.Attributes.Add("placeholder", placeholder);
            tagBuilder.Attributes.Add("class", cssClass);

            return tagBuilder;
        }
    }
}
