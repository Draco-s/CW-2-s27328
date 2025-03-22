namespace Cwiczenie_2;

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
        masaladunku = masaladunku;
        wysokosc = wysokosc;
        wagawlasnakontenera = wagawlasnakontenera;
        glebokosc = glebokosc;

        numerseryjny = Generowanienumeruseryjnego();


    }

    private string Generowanienumeruseryjnego()
    {
        string typ = "C";
        string numerseryjny = $"KON-{typ}-{ostatninumerseryjny++}";
        return numerseryjny;
    }

    public double maksymalnaladownosc()
    {
        return masaladunku + wagawlasnakontenera;
    }
}