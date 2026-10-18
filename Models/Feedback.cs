using System.ComponentModel.DataAnnotations;

namespace FeedbackManagement.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 60 characters.")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [RegularExpression(@"^\+?[0-9]{10,13}$", ErrorMessage = "Phone must be 10 to 13 digits (optional + prefix).")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please give a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? Rating { get; set; }

        [Required(ErrorMessage = "Please write your comments.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Comments must be between 10 and 500 characters.")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        [Display(Name = "I would recommend this to others")]
        public bool WouldRecommend { get; set; }

        [Required(ErrorMessage = "Visit date is required.")]
        [DataType(DataType.Date)]
        [NotFutureDate(ErrorMessage = "Visit date cannot be in the future.")]
        [Display(Name = "Visit Date")]
        public DateTime? VisitDate { get; set; }

        [Display(Name = "Submitted On")]
        public DateTime SubmittedOn { get; set; } = DateTime.Now;
    }
}
