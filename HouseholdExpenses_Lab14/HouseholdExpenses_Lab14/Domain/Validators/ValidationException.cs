namespace HouseholdExpenses_Lab14.Domain.Validators;

public class ValidationException : ApplicationException
{
    public ValidationException(String message) : base(message)
    {
        
    }
}