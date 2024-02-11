using HouseholdExpenses_Lab14.Domain;
using HouseholdExpenses_Lab14.Domain.Validators;

namespace HouseholdExpenses_Lab14.Repository;

public class InMemoryRepository<TId,TE> : IRepository<TId,TE> where TE : Entity<TId>
{
    protected IValidator<TE> _validator;
    protected IDictionary<TId, TE> _entities = new Dictionary<TId, TE>();

    public InMemoryRepository(IValidator<TE> validator)
    {
        _validator = validator;
    }
    
    protected TE FindOne(TId id)
    {
        if (_entities.ContainsKey(id))
            return _entities[id];
        return null;
    }

    public IEnumerable<TE> FindAll()
    {
        return _entities.Values;
    }

    public TE Save(TE entity)
    {
        if (_entities.ContainsKey(entity.Id))
            throw new RepositoryException($"{entity.Id} already exists in Memory!");
        _entities.Add(entity.Id,entity);
        return entity;
    }

    public TE Delete(TId id)
    {
        if (_entities.ContainsKey(id))
            throw new RepositoryException($"{id} does not exist!");
        TE ob = _entities[id];
        _entities.Remove(id);
        return ob;
    }

    public TE Update(TE entity)
    {
        if (!_entities.ContainsKey(entity.Id))
            throw new Exception($"{entity.Id} does not exist in dictionary!");
        _entities[entity.Id] = entity;
        return entity;
    }
}