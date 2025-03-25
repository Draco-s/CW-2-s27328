namespace Cwiczenie_2;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    public double Cisnienie { get; }

    public KontenerNaGaz(double masaladunku, double wysokosc, double wagawlasnakontenera, double glebokosc, double cisnienie)
        : base(masaladunku, wysokosc, wagawlasnakontenera, glebokosc)
    {
        Cisnienie = cisnienie;
    }
    public void Zaladuj(double masa)
    {
        if (Maksymalnaladownosc() < masa + wagawlasnakontenera)
        {
            NotifyHazard($"Próba przepełnienia kontenera {numerseryjny} gazem! Masa {masa} kg przekracza pojemność.");
            throw new OverfillException("Niebezpieczna operacja! Przekroczono dozwolony poziom napełnienia gazem.");
        }

        masaladunku += masa;
    }
    public void Oproznij()
    {
        double pozostalaMasa = masaladunku * 0.05; // 5% pozostaje
        masaladunku = pozostalaMasa;
        NotifyHazard($"Opróżniono kontener {numerseryjny}, pozostawiono 5% ładunku ({pozostalaMasa} kg).");
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[ALERT] {message}");
    }
}
