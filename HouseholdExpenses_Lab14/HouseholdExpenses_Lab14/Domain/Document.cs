namespace HouseholdExpenses_Lab14.Domain;

public class Document : Entity<string>
{
    public Document(){}
    public string Nume { get; set; }
    public DateTime DataEmitere { get; set; }

    public Document(String nume, DateTime dataEmitere)
    {
        this.Nume = nume;
        this.DataEmitere = dataEmitere;
    }

    public override string ToString()
    {
        return Id + "," + Nume + "," + DataEmitere;
    }

    
}