using System.Text.RegularExpressions;
using HouseholdExpenses_Lab14.Domain;
using HouseholdExpenses_Lab14.Domain.Enum;
using HouseholdExpenses_Lab14.Repository;
using HouseholdExpenses_Lab14.Repository.FileRepository;

namespace HouseholdExpenses_Lab14;

public class Service
{
    private IRepository<string, Document> _documenteFileRepo;
    private IRepository<string, Factura> _facturiFileRepo;
    private IRepository<string, Achizitie> _achizitiiFileRepo;

    public Service(DocumenteFileRepo documenteFileRepo, FacturiFileRepo facturiFileRepo,
        AchizitiiFileRepo achizitiiFileRepo)
    {
        _documenteFileRepo = documenteFileRepo;
        _facturiFileRepo = facturiFileRepo;
        _achizitiiFileRepo = achizitiiFileRepo;
    }

    public List<Document> getDocumenteFullyInitiated()
    {
        return (List<Document>)_documenteFileRepo.FindAll();
    }

    public List<Factura> getFacturiDocumentInitiated()
    {
        var documents = _documenteFileRepo.FindAll();
        var facturi = _facturiFileRepo.FindAll();
        var result = from factura in facturi
            join document in documents on factura.Id equals document.Id
            select new Factura
            {
                Categorie = factura.Categorie,
                Achizitii = factura.Achizitii,
                DataEmitere = document.DataEmitere,
                DataScadenta = factura.DataScadenta,
                Id = factura.Id,
                Nume = document.Nume
            };
        return result.ToList();
    }

    public List<Factura> getFacturiWithAchizitiiInitiated()
    {
        var facturi = getFacturiDocumentInitiated();
        var achizitii = _achizitiiFileRepo.FindAll();

        var result = facturi.GroupJoin(
            achizitii,
            factura => factura.Id, // Key selector for facturi
            achizitie => achizitie.IdFactura, // Key selector for achizitii
            (factura, achizitiiGroup) => new Factura
            {
                Id = factura.Id, // assuming Id is a property in Factura
                // Other properties of Factura
                Nume = factura.Nume,
                Categorie = factura.Categorie,
                DataEmitere = factura.DataEmitere,
                DataScadenta = factura.DataScadenta,
                Achizitii = achizitiiGroup.ToList() // List of associated Achizitii
                
            }
        ).ToList();

        return result;
    }

    public List<Achizitie> getAchizitiiFullyInitiated()
    {
        var achiztii = _achizitiiFileRepo.FindAll();
        var facturi = getFacturiDocumentInitiated();
        var result = from achizitie in achiztii
            join factura in facturi on achizitie.IdFactura equals factura.Id
            select new Achizitie
            {
                Cantitate = achizitie.Cantitate,
                Factura = factura,
                Id = achizitie.Id,
                IdFactura = factura.Id,
                PretProdus = achizitie.PretProdus,
                Produs = achizitie.Produs
            };
        return result.ToList();

    }

    //cerinta 1
    public List<DocumentDTO> getAllDocumentsByYear(int year)
    {
        var docs = _documenteFileRepo.FindAll();
        var result = from doc in docs
            where doc.DataEmitere.Year == year
            select new DocumentDTO
            {
                DataEmitere = doc.DataEmitere,
                Nume = doc.Nume
            };
        return result.ToList();
    }

    //cerinta 2
    public List<FacturaDTO1> getAllFacturiScadenteLunaAsta()
    {
        int luna = DateTime.Now.Month;
        int an = DateTime.Now.Year;
        var facturi = getFacturiDocumentInitiated();
        var result = from factura in facturi
            where factura.DataScadenta.Month == luna && factura.DataScadenta.Year==an
            select new FacturaDTO1
            {
                DataScadenta = factura.DataScadenta,
                Nume = factura.Nume
            };
        return result.ToList();
    }

    //cerinta 3
    public List<FacturaDTO2> getAllFacturiCuCelPutin3Achizitii()
    {
        var facturi = getFacturiWithAchizitiiInitiated();
        var result = from factura in facturi
            where factura.Achizitii.Sum(a => a.Cantitate) >= 3
            select new FacturaDTO2
            {
                Nume = factura.Nume,
                NrProduse = factura.Achizitii.Sum(a => a.Cantitate)
            };
        return result.ToList();
    }

    //cerinta 4
    public List<AchizitieDTO> getAchizitiiUtilities()
    {
        var achizitii = getAchizitiiFullyInitiated();
        var result = from achizitie in achizitii
            where achizitie.Factura.Categorie == Category.Utilities
            select new AchizitieDTO
            {
                Produs = achizitie.Produs,
                NumeFactura = achizitie.Factura.Nume
            };
        return result.ToList();
    }

    //cerinta 5
    public Category getCategoriaCuCeleMaiMulteCheltuieli()
    {
        var facturi = getFacturiWithAchizitiiInitiated();
        var result = facturi
            .Where(factura => factura.Achizitii != null)
            .GroupBy(factura => factura.Categorie)
            .Select(group => new
            {
                Categoria = group.Key,
                TotalCheltuieli = group.Sum(factura => factura.Achizitii.Sum(achizitie => achizitie.PretProdus))
            })
            .OrderByDescending(item => item.TotalCheltuieli)
            .FirstOrDefault();
        return result?.Categoria ?? Category.Utilities;

    }

    public void all()
    {
        getAllDocumentsByYear(2023).ForEach(doc=>Console.WriteLine(doc));
        Console.WriteLine("---------------------------------------");
       //2
        getAllFacturiScadenteLunaAsta().ForEach(doc=>Console.WriteLine(doc));
        Console.WriteLine("---------------------------------------");
        //3
        getAllFacturiCuCelPutin3Achizitii().ForEach(doc=>Console.WriteLine(doc));
        Console.WriteLine("---------------------------------------");
        //4
        getAchizitiiUtilities().ForEach(doc=>Console.WriteLine(doc));
        Console.WriteLine("---------------------------------------");
        //5
        Console.WriteLine(getCategoriaCuCeleMaiMulteCheltuieli());
        Console.WriteLine("---------------------------------------");
    }
}