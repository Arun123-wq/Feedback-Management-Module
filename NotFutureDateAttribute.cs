using System.ComponentModel.DataAnnotations;

namespace FeedbackManagement.Models
{
    /// <summary>
    /// Custom validation attribute: the date must not be in the future.
    /// </summary>
    public class NotFutureDateAttribute : ValidationAttribute
    {
        public NotFutureDateAttribute()
        {
            ErrorMessage = "{0} cannot be a future date.";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;           // [Required] handles nulls
            return value is DateTime date && date.Date <= DateTime.Today;
        }
    }
}
