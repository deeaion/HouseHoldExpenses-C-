namespace HouseholdExpenses_Lab14.Domain;

public class Achizitie : Entity<string>
{
    public string Produs { get; set; }
    public int Cantitate { get; set; }
    public double PretProdus { get; set; }
    public string IdFactura { get; set; }
    public Factura? Factura { get; set; }
    public override string ToString()
    {
        return Id + "," + Produs+","+Cantitate+","+
               PretProdus+","+IdFactura;
    }

    public Achizitie(string produs, int cantitate, double pretProdus, Factura? factura,String idFactura)
    {
        Produs = produs;
        Cantitate = cantitate;
        PretProdus = pretProdus;
        Factura = factura;
        IdFactura = idFactura;
    }

    public Achizitie()
    {
        
    }
}