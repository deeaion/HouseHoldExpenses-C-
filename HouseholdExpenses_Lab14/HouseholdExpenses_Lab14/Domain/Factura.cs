using HouseholdExpenses_Lab14.Domain.Enum;

namespace HouseholdExpenses_Lab14.Domain;

public class Factura : Document
{
    public Factura(){}

    public Factura(string nume, DateTime dataEmitere, DateTime dataScadenta, List<Achizitie> achizitii, Category categorie)
    {
        Nume = nume;
        DataEmitere = dataEmitere;
        DataScadenta = dataScadenta;
        Achizitii = achizitii;
        Categorie = categorie;
    }

    public DateTime DataScadenta { get; set; }
    public List<Achizitie> Achizitii { get; set; }
    public Category Categorie { get; set; }
    public override string ToString()
    {
        return Id + "," + DataScadenta+","+Categorie;
    }
}