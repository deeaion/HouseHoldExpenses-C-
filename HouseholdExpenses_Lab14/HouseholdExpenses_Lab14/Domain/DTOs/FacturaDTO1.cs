namespace HouseholdExpenses_Lab14.Domain;

public class FacturaDTO1
{
    public FacturaDTO1(string nume, DateTime dataScadenta)
    {
        Nume = nume;
        DataScadenta = dataScadenta;
    }

    public FacturaDTO1()
    {
        
    }

    public string Nume { get; set; }
    public DateTime DataScadenta { get; set; }
    public override string ToString()
    {
        return $"Nume:{Nume},DataScadenta{DataScadenta}";
    }
}