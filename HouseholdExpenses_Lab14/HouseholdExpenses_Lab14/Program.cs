// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using HouseholdExpenses_Lab14;
using HouseholdExpenses_Lab14.Domain.Enum;
using HouseholdExpenses_Lab14.Repository.FileRepository;

Console.WriteLine("Hello, World!");

static void PrintMenu()
{
    Console.WriteLine("Alege una din optiuniile de mai jos:");
    Console.WriteLine("1.Sa se afișeze toate documentele (nume, dataEmitere) emise in anul 2023.");
    Console.WriteLine("2.Sa se afișeze toate facturile (nume, dataScadenta) scadente in luna curenta.");
    Console.WriteLine("3.Sa se afiseze toate facturile (nume, nrProduse) cu cel putin 3 produse achizitionate.");
    Console.WriteLine("4.Sa se afișeze toate achizitiile (produs, numeFactura) din categoria Utilities.");
    Console.WriteLine("5.Sa se afișeze categoria de facturi care a înregistrat cele mai multe cheltuieli.");
    Console.WriteLine("0.Exit");
}
static void Main()
{
    DocumenteFileRepo documenteFileRepo = new DocumenteFileRepo(null, "..\\..\\..\\Files\\documente.txt");
    AchizitiiFileRepo achizitiiFileRepo = new AchizitiiFileRepo(null, "..\\..\\..\\Files\\achizitii.txt");
    FacturiFileRepo facturiFileRepo = new FacturiFileRepo(null, "..\\..\\..\\Files\\facturi.txt");

    Service serviceA = new Service(documenteFileRepo, facturiFileRepo, achizitiiFileRepo);
    
    // Call the method and print the result
    /*var fullyInitiatedAchizitii = serviceA.getAchizitiiFullyInitiated();
    foreach (var achizitie in fullyInitiatedAchizitii)
    {
        Console.WriteLine($"Achizitie ID: {achizitie.Id}, Produs: {achizitie.Produs}, Factura nume:{achizitie.Factura.Nume}.");
    }

    var a2 = serviceA.getFacturiWithAchizitiiInitiated();
    foreach (var factura in a2)
    {
        Console.WriteLine($"Id Factura {factura.Id} si achizitii: \n");
        if (factura.Achizitii != null)
        {
            foreach (var VARIABLE in factura.Achizitii)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
    Console.WriteLine("---------------------------");
    serviceA.all();*/
    while (true)
    {
        PrintMenu();
        string Option = Console.ReadLine();
        switch (Option)
        {
            case "1":
            {
                serviceA.getAllDocumentsByYear(2023).ForEach(Console.WriteLine);
                break;
            }
            case "2":
            {
                serviceA.getAllFacturiScadenteLunaAsta().ForEach(Console.WriteLine);
                break;
            }
            case "3":
            {
                serviceA.getAllFacturiCuCelPutin3Achizitii().ForEach(Console.WriteLine);
                break;
            }
            case "4":
            {
                serviceA.getAchizitiiUtilities().ForEach(Console.WriteLine);
                break;
            }
            case "5":
            {
                Console.WriteLine(serviceA.getCategoriaCuCeleMaiMulteCheltuieli());
                break;
            }
            case "0":
            {
                Console.WriteLine("Bye bye!");
                return;
            }
            default:
            {Console.WriteLine("Invalid comand! Try again");
                break;
         }
    }
    }
}

Main();