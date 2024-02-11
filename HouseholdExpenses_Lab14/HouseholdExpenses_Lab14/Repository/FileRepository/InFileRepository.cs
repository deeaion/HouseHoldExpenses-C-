
using HouseholdExpenses_Lab14.Domain;
using HouseholdExpenses_Lab14.Domain.Validators;

namespace HouseholdExpenses_Lab14.Repository.FileRepository;

public abstract class InFileRepository<TId,TE> : InMemoryRepository<TId,TE> 
                where TE : Entity<TId>
{
    private string _fileName;
    public InFileRepository(IValidator<TE> validator,string fileName) : base(validator)
    {
        _fileName = fileName;
        ReadFromFile();
    }
    protected abstract TE EntityFromString(string? data);
    protected void ReadFromFile()
    {
        if (_fileName==null)
        {
            throw new RepositoryException("Invalid parameter!");
        }
        StreamReader streamReader = new StreamReader(_fileName);
        string? data;
        while (true)
        {
            data = streamReader.ReadLine();
            if(data==null)
                break;
            Save(EntityFromString(data));
        }
    }
}