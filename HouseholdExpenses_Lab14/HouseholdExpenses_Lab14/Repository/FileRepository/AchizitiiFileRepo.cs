using HouseholdExpenses_Lab14.Domain;
using HouseholdExpenses_Lab14.Domain.Validators;

namespace HouseholdExpenses_Lab14.Repository.FileRepository;

public class AchizitiiFileRepo : InFileRepository<string,Achizitie>
{
 
    public AchizitiiFileRepo(IValidator<Achizitie> validator, string fileName) : base(validator, fileName)
    {
       
    }

    protected override Achizitie EntityFromString(string? data)
    {
        string[] properties = data.Split(',');
        //achizitie -> produs,cantitate,pretProdus,factura
        
        
        
        string idAchizitie = properties[0];
        string produs = properties[1];
        int cantitate = int.Parse(properties[2]);
        double pretProdus = double.Parse(properties[3]);
        string idFactura = properties[4];
        //now i need to get factura
        Achizitie achizitie=new Achizitie(produs, cantitate, pretProdus, null, idFactura);
        achizitie.Id = idAchizitie;
        return achizitie;
    }
    
}