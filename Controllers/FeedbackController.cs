using FeedbackManagement.Models;
using FeedbackManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _repo;

        public FeedbackController(IFeedbackRepository repo)
        {
            _repo = repo;
        }

        // GET: /Feedback
        public IActionResult Index(string search, string category)
        {
            var items = _repo.GetAll();

            if (!string.IsNullOrWhiteSpace(search))
            {
                items = items.Where(f =>
                    f.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    f.Comments.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                items = items.Where(f => f.Category == category);
            }

            var vm = new FeedbackListViewModel
            {
                Items = items.ToList(),
                Search = search,
                Category = category
            };
            return View(vm);
        }

        // GET: /Feedback/Create
        public IActionResult Create()
        {
            return View(new Feedback { VisitDate = DateTime.Today });
        }

        // POST: /Feedback/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Email,Phone,Category,Rating,Comments,WouldRecommend,VisitDate")] Feedback model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);   // redisplay with validation messages
            }

            _repo.Add(model);
            TempData["Success"] = "Thank you! Your feedback has been submitted.";
            return RedirectToAction(nameof(ThankYou));
        }

        public IActionResult ThankYou() => View();

        // GET: /Feedback/Details/5
        public IActionResult Details(int id)
        {
            var item = _repo.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // GET: /Feedback/Edit/5
        public IActionResult Edit(int id)
        {
            var item = _repo.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: /Feedback/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Email,Phone,Category,Rating,Comments,WouldRecommend,VisitDate")] Feedback model)
        {
            model.Id = id;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!_repo.Update(model)) return NotFound();

            TempData["Success"] = "Feedback updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Feedback/Delete/5
        public IActionResult Delete(int id)
        {
            var item = _repo.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: /Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_repo.Delete(id))
                TempData["Success"] = "Feedback deleted.";
            else
                TempData["Error"] = "Feedback not found.";

            return RedirectToAction(nameof(Index));
        }
    }
}
