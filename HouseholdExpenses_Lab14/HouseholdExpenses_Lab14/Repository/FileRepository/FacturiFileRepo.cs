using HouseholdExpenses_Lab14.Domain;
using HouseholdExpenses_Lab14.Domain.Enum;
using HouseholdExpenses_Lab14.Domain.Validators;

namespace HouseholdExpenses_Lab14.Repository.FileRepository;

public class FacturiFileRepo: InFileRepository<string,Factura>
{
    private string _fileFacturi;
    public FacturiFileRepo(IValidator<Factura> validator, string fileName) : base(validator, fileName)
    {
        _fileFacturi = fileName;
    }

    protected override Factura EntityFromString(string? data)
    {
        string[] properties = data.Split(',');
        //facturi -> idDocument,data Scadenta,Categorie
        
        string idDocument = properties[0];
        DateTime dataScadenta = Convert.ToDateTime(properties[1]);
        Category categorie = (Category)Enum.Parse(typeof(Category), properties[2]);
        Factura factura = new Factura(null, dataScadenta, dataScadenta, null, categorie);
        factura.Id = idDocument;
        return factura;
    }
}