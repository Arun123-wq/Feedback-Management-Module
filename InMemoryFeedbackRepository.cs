using FeedbackManagement.Models;

namespace FeedbackManagement.Services
{
    public class InMemoryFeedbackRepository : IFeedbackRepository
    {
        private readonly List<Feedback> _items = new();
        private readonly object _lock = new();
        private int _nextId = 1;

        public InMemoryFeedbackRepository()
        {
            // Seed data
            Add(new Feedback { Name = "Aarav Patel", Email = "aarav@example.com", Phone = "9876543210",
                Category = "Product Quality", Rating = 5, WouldRecommend = true,
                Comments = "Excellent quality, exactly as described. Very happy!", VisitDate = DateTime.Today.AddDays(-10) });
            Add(new Feedback { Name = "Diya Shah", Email = "diya@example.com",
                Category = "Delivery", Rating = 3, WouldRecommend = false,
                Comments = "Delivery was a bit late but the packaging was good.", VisitDate = DateTime.Today.AddDays(-4) });
            Add(new Feedback { Name = "Rohan Mehta", Email = "rohan@example.com", Phone = "+919812345678",
                Category = "Customer Service", Rating = 4, WouldRecommend = true,
                Comments = "Support team resolved my issue quickly and politely.", VisitDate = DateTime.Today.AddDays(-1) });
        }

        public IEnumerable<Feedback> GetAll()
        {
            lock (_lock) return _items.OrderByDescending(f => f.SubmittedOn).ThenByDescending(f => f.Id).ToList();
        }

        public Feedback GetById(int id)
        {
            lock (_lock) return _items.FirstOrDefault(f => f.Id == id);
        }

        public void Add(Feedback feedback)
        {
            lock (_lock)
            {
                feedback.Id = _nextId++;
                feedback.SubmittedOn = DateTime.Now;
                _items.Add(feedback);
            }
        }

        public bool Update(Feedback feedback)
        {
            lock (_lock)
            {
                var existing = _items.FirstOrDefault(f => f.Id == feedback.Id);
                if (existing == null) return false;

                existing.Name = feedback.Name;
                existing.Email = feedback.Email;
                existing.Phone = feedback.Phone;
                existing.Category = feedback.Category;
                existing.Rating = feedback.Rating;
                existing.Comments = feedback.Comments;
                existing.WouldRecommend = feedback.WouldRecommend;
                existing.VisitDate = feedback.VisitDate;
                return true;
            }
        }

        public bool Delete(int id)
        {
            lock (_lock)
            {
                var existing = _items.FirstOrDefault(f => f.Id == id);
                return existing != null && _items.Remove(existing);
            }
        }
    }
}
