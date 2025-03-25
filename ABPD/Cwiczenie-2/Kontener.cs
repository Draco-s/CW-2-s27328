namespace Cwiczenie_2;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}
public interface IHazardNotifier
{
    void NotifyHazard(string message);
}

public class Kontener
{
    public double masaladunku { get; set; }
    public double wysokosc { get; set; }
    public double wagawlasnakontenera { get; set; }
    public double glebokosc { get; set; }
    public string numerseryjny { get; set; }
    
    private static int ostatninumerseryjny = 1;

    public Kontener(double masaladunku, double wysokosc, double wagawlasnakontenera, double glebokosc)
    {
        this.masaladunku = masaladunku;
        this.wysokosc = wysokosc;
        this.wagawlasnakontenera = wagawlasnakontenera;
        this.glebokosc = glebokosc;

        numerseryjny = Generowanienumeruseryjnego();


    }

    private string Generowanienumeruseryjnego()
    {
        string typ = "C";
        string numerseryjny = $"KON-{typ}-{ostatninumerseryjny++}";
        return numerseryjny;
    }

    public double Maksymalnaladownosc()
    {
        return masaladunku + wagawlasnakontenera;
    }
    public void Zaladuj(double masa)
    {
        if (Maksymalnaladownosc() < masa +wagawlasnakontenera)
        {
            throw new OverfillException("Przekroczono maksymalną ładowność kontenera!");
        }
        masaladunku += masa;
    }

    public void Oproznij()
    {
        masaladunku = 0;
    }
    public override string ToString()
    {
        return $"{numerseryjny} - Masa ładunku: {masaladunku} kg, Waga własna: {wagawlasnakontenera} kg";
    }
}
