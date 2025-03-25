namespace Cwiczenie_2;

public class KontenerNaPlyny : Kontener, IHazardNotifier
{
    public bool CzyNiebezpieczny { get; }

    public KontenerNaPlyny(double masaladunku,double wysokosc, double wagawlasnakontenera, double glebokosc, bool czyNiebezpieczny)
        : base(masaladunku,wysokosc, wagawlasnakontenera, glebokosc)
    {
        CzyNiebezpieczny = czyNiebezpieczny;
    }
    public void Zaladuj(double masa)
    {
        double limit = CzyNiebezpieczny ? 0.5 : 0.9;
        double maksymalnaMasa = Maksymalnaladownosc() * limit;

        if (masa > maksymalnaMasa)
        {
            NotifyHazard($"Próba załadowania {masa} kg do kontenera {numerseryjny}, co przekracza dozwolony limit ({limit * 100}% pojemności).");
            throw new OverfillException("Niebezpieczna operacja! Przekroczono dozwolony poziom napełnienia.");
        }

        base.Zaladuj(masa);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[ALERT] {message}");
    }
}
