using HouseholdExpenses_Lab14.Domain;
using HouseholdExpenses_Lab14.Domain.Validators;

namespace HouseholdExpenses_Lab14.Repository.FileRepository;

public class DocumenteFileRepo:InFileRepository<string,Document>
{
    private string _fileDocumente;
    public DocumenteFileRepo(IValidator<Document> validator, string fileName) : base(validator, fileName)
    {
        _fileDocumente = fileName;
    }

    protected override Document EntityFromString(string? data)
    {
        string[] properties = data.Split(',');
        //document -> id,nume,dataemitere
        
        string idDocument = properties[0];
        string nume = properties[1];
        DateTime dataEmitere = DateTime.Parse(properties[2]);

        Document document = new Document(nume, dataEmitere);
        document.Id = idDocument;
        return document;
    }
}