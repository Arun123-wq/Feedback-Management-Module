# Feedback Management Module (ASP.NET Core MVC, .NET 8)

Demonstrates: MVC pattern, Layout page, Partial Views, HTML Helpers, and Validation.

## How to run
**Visual Studio 2022:** open `FeedbackManagement.csproj` (File > Open > Project) and press F5.

**Command line** (needs .NET 8 SDK):

    cd FeedbackManagement
    dotnet run

Then open the URL shown in the console (e.g. http://localhost:5000).

## Structure
- `Models/Feedback.cs`          Data annotations (Required, StringLength, EmailAddress, Range, RegularExpression, custom NotFutureDate)
- `Controllers/FeedbackController.cs`  Index (search/filter), Create, Details, Edit, Delete
- `Services/`                   Repository interface + in-memory implementation (no database needed)
- `Helpers/RatingHelper.cs`     Custom HTML helper `@Html.RatingStars(n)`
- `Views/Shared/_Layout.cshtml` Master layout with navbar, footer, RenderBody, Scripts section
- `Views/Shared/_FeedbackForm.cshtml`    Partial view - form fields shared by Create & Edit
- `Views/Shared/_FeedbackRow.cshtml`     Partial view - table row
- `Views/Shared/_FeedbackSummary.cshtml` Partial view - statistics cards
- `Views/Shared/_Alerts.cshtml`          Partial view - TempData messages
- `Views/Shared/_ValidationScriptsPartial.cshtml`  jQuery client-side validation

## Validation
Server-side via Data Annotations + ModelState.IsValid; client-side via jQuery Unobtrusive Validation.
Internet access is needed for the Bootstrap/jQuery CDN links.
