using Microsoft.AspNetCore.Mvc;

namespace FeedbackManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Error() => View();
    }
}
