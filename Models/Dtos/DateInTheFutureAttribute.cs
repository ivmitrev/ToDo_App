using System.ComponentModel.DataAnnotations;

namespace TodoAppApi.Entities;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class DateInTheFutureAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        var futureDate = value as DateOnly?;
        var memberNames = new List<string>() { context.MemberName };

        if (futureDate != null)
        {
            if (futureDate.Value < DateOnly.FromDateTime(DateTime.Now))
            {
                return new ValidationResult("This must be a date in the future", memberNames);
            }
        }

        return ValidationResult.Success;
    }
}