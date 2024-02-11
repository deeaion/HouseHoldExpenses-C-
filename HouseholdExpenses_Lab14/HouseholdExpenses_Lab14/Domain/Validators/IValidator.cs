namespace HouseholdExpenses_Lab14.Domain.Validators;

public interface IValidator<TE>
{
    void Validate(TE e);
}