using System.ComponentModel.DataAnnotations;

namespace GTS_Task.Helpers
{
    public static class DateValidator
    {
        public static ValidationResult ValidateFutureDate(DateTime? date)
        {
            if (!date.HasValue)
                return ValidationResult.Success;

            if (date.Value.Date < DateTime.UtcNow.Date)
                return new ValidationResult("Due date must be today or in the future.");

            return ValidationResult.Success;
        }
    }
}
