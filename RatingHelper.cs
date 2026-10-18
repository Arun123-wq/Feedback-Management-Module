using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FeedbackManagement.Helpers
{
    /// <summary>
    /// Custom HTML Helper:  @Html.RatingStars(4)  =>  ★★★★☆
    /// </summary>
    public static class RatingHelper
    {
        public static IHtmlContent RatingStars(this IHtmlHelper html, int? rating, int max = 5)
        {
            int value = Math.Clamp(rating ?? 0, 0, max);

            var span = new TagBuilder("span");
            span.AddCssClass("rating-stars");
            span.Attributes["title"] = $"{value} out of {max}";
            span.InnerHtml.Append(new string('★', value) + new string('☆', max - value));
            return span;
        }
    }
}
