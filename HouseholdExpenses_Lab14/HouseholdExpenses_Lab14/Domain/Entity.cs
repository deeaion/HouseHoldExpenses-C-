namespace HouseholdExpenses_Lab14.Domain;

public class Entity<TId>
{
    public Entity(){}
    public Entity(TId id)
    {
        this.Id = id;
    }

    public TId Id
    {
        get;
        set;
    } = default!;
}