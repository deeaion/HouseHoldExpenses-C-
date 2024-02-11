namespace HouseholdExpenses_Lab14.Domain;

public class AchizitieDTO
{
    public string Produs { get; set; }
    public string NumeFactura { get; set; }

    public AchizitieDTO(string produs, string numeFactura)
    {
        Produs = produs;
        NumeFactura = numeFactura;
    }

    public AchizitieDTO()
    {
        
    }

    public override string ToString()
    {
        return $"Produs:{Produs},NumeFactura:{NumeFactura}";
        
    }
}