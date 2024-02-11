namespace HouseholdExpenses_Lab14.Domain;

public class DocumentDTO
{
    public DocumentDTO(string nume, DateTime dataEmitere)
    {
        Nume = nume;
        DataEmitere = dataEmitere;
    }

    public DocumentDTO()
    {
        
    }

    public string Nume { get; set; }
    public DateTime DataEmitere { get; set; }
    public override string ToString()
    {
        return $"Nume:{Nume},DataEmitere:{DataEmitere}";
    }
}