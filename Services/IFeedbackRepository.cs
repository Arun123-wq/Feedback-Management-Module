using FeedbackManagement.Models;

namespace FeedbackManagement.Services
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAll();
        Feedback GetById(int id);
        void Add(Feedback feedback);
        bool Update(Feedback feedback);
        bool Delete(int id);
    }
}
