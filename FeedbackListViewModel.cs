namespace FeedbackManagement.Models
{
    public class FeedbackListViewModel
    {
        public List<Feedback> Items { get; set; } = new();
        public string Search { get; set; }
        public string Category { get; set; }
        public int Total => Items.Count;
        public double AverageRating => Items.Count == 0 ? 0 : Items.Average(f => f.Rating ?? 0);
        public int RecommendCount => Items.Count(f => f.WouldRecommend);
    }
}
