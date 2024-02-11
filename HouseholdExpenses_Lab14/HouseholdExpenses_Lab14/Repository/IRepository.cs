using HouseholdExpenses_Lab14.Domain;

namespace HouseholdExpenses_Lab14.Repository;

interface IRepository<TId,TE> where TE : Entity<TId>
{
  
    IEnumerable<TE> FindAll();
   
}