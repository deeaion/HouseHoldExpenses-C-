namespace HouseholdExpenses_Lab14.Domain;

public class FacturaDTO2
{
    public FacturaDTO2(string nume, int nrProduse)
    {
        Nume = nume;
        NrProduse = nrProduse;
        
    }

    public FacturaDTO2()
    {
        
    }

    public string Nume { get; set; }
    public int NrProduse { get; set; }
    public override string ToString()
    {
        return $"Nume:{Nume},NrProduse:{NrProduse}";
    }
}