namespace Cwiczenie_2;

public class Kontenerowiec
{
     public List<Kontener> Kontenery { get; private set; }
    public double MaksymalnaPredkosc { get; } // Węzły
    public int MaksymalnaLiczbaKontenerow { get; }
    public double MaksymalnaLadownosc { get; } // W tonach (1 tona = 1000 kg)

    public Kontenerowiec(double maksymalnaPredkosc, int maksymalnaLiczbaKontenerow, double maksymalnaLadownosc)
    {
        MaksymalnaPredkosc = maksymalnaPredkosc;
        MaksymalnaLiczbaKontenerow = maksymalnaLiczbaKontenerow;
        MaksymalnaLadownosc = maksymalnaLadownosc;
        Kontenery = new List<Kontener>();
    }

    public void ZaladujKontener(Kontener kontener)
    {
        if (Kontenery.Count >= MaksymalnaLiczbaKontenerow)
        {
            throw new InvalidOperationException("Przekroczono maksymalną liczbę kontenerów na statku!");
        }

        double aktualnaWaga = Kontenery.Sum(k => k.masaladunku + k.wagawlasnakontenera);
        if (aktualnaWaga + (kontener.masaladunku + kontener.wagawlasnakontenera) > MaksymalnaLadownosc * 1000) // Przeliczenie ton na kg
        {
            throw new InvalidOperationException("Przekroczono maksymalną ładowność statku!");
        }

        Kontenery.Add(kontener);
        Console.WriteLine($"Załadowano kontener {kontener.numerseryjny}. Aktualna liczba kontenerów: {Kontenery.Count}");
    }

    public void RozladujKontener(string numerSeryjny)
    {
        var kontener = Kontenery.FirstOrDefault(k => k.numerseryjny == numerSeryjny);
        if (kontener == null)
        {
            throw new InvalidOperationException("Nie znaleziono kontenera o podanym numerze seryjnym.");
        }

        Kontenery.Remove(kontener);
        Console.WriteLine($"Rozładowano kontener {numerSeryjny}. Pozostało {Kontenery.Count} kontenerów.");
    }
    public void ZaladujListeKontenerow(List<Kontener> listaKontenerow)
    {
        foreach (var kontener in listaKontenerow)
        {
            ZaladujKontener(kontener);
        }
    }

    public void ZamienKontener(string numerSeryjny, Kontener nowyKontener)
    
        {
            for (int i = 0; i < Kontenery.Count; i++)
            {
                if (Kontenery[i].numerseryjny == numerSeryjny)
                {
                    double aktualnaWaga = ObliczWageLadunku();
                    double wagaPoZmianie = aktualnaWaga - Kontenery[i].Maksymalnaladownosc() +
                                           nowyKontener.Maksymalnaladownosc();

                    if (wagaPoZmianie > MaksymalnaLadownosc)
                    {
                        Console.WriteLine("Zamiana niemożliwa! Nowy kontener przekroczy dopuszczalną wagę statku.");
                        return;
                    }

                    Kontenery[i] = nowyKontener;
                    Console.WriteLine(
                        $"Kontener {numerSeryjny} zastąpiony nowym kontenerem {nowyKontener.numerseryjny}.");
                    return;
                }
            }

            Console.WriteLine("Nie znaleziono kontenera o podanym numerze seryjnym.");
        }
    public void PrzeniesKontener(string numerSeryjny, Kontenerowiec docelowyStatek)
    {
        Kontener kontenerDoPrzeniesienia = Kontenery.FirstOrDefault(k => k.numerseryjny == numerSeryjny);
        if (kontenerDoPrzeniesienia == null)
        {
            Console.WriteLine("Nie znaleziono kontenera do przeniesienia.");
            return;
        }

        if (docelowyStatek.Kontenery.Count >= docelowyStatek.MaksymalnaLiczbaKontenerow)
        {
            Console.WriteLine("Docelowy statek nie ma miejsca na kontener.");
            return;
        }

        if (docelowyStatek.ObliczWageLadunku() + kontenerDoPrzeniesienia.Maksymalnaladownosc() > docelowyStatek.MaksymalnaLadownosc)
        {
            Console.WriteLine("Docelowy statek nie może przyjąć więcej ładunku (przekroczenie wagi).");
            return;
        }

        Kontenery.Remove(kontenerDoPrzeniesienia);
        docelowyStatek.ZaladujKontener(kontenerDoPrzeniesienia);
        Console.WriteLine($"Przeniesiono kontener {numerSeryjny} na inny statek.");
    }
    

    private double ObliczWageLadunku()
        {
            return Kontenery.Sum(k => k.Maksymalnaladownosc());
        }

    public void WyswietlInformacjeOStatku()
    {
        Console.WriteLine($"Kontenerowiec - Maksymalna prędkość: {MaksymalnaPredkosc} węzłów");
        Console.WriteLine($"Maksymalna liczba kontenerów: {MaksymalnaLiczbaKontenerow}");
        Console.WriteLine($"Maksymalna ładowność: {MaksymalnaLadownosc} ton");
        Console.WriteLine($"Aktualna liczba kontenerów: {Kontenery.Count}");
        Console.WriteLine($"Aktualna masa ładunku: {Kontenery.Sum(k => k.masaladunku + k.wagawlasnakontenera) / 1000} ton \n");

        foreach (var kontener in Kontenery)
        {
            Console.WriteLine($"- {kontener.numerseryjny}: {kontener.masaladunku} kg + {kontener.wagawlasnakontenera} kg (kontener)");
        }
    }
}
