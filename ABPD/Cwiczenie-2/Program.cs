// See https://aka.ms/new-console-template for more information
namespace Cwiczenie_2;
class Program
{
    static void Main()
    {
        Console.WriteLine("Tworzymy dwa statki...");

        Kontenerowiec statek1 = new Kontenerowiec(25, 200, 200_000); 
        Kontenerowiec statek2 = new Kontenerowiec(30, 195, 180_000); 

        Console.WriteLine("\nTworzymy kontenery...");
        Kontener kontener1 = new Kontener(5267, 1090, 2478, 5600);
        Kontener kontener2 = new Kontener(10000, 2057, 1200, 7871);
        Kontener kontener3 = new Kontener(9999,2533 , 1100, 10222);
        Kontener kontener4 = new Kontener(8000, 870, 1378, 9750);

        Console.WriteLine("\nZaładunek pojedynczych kontenerów na statek 1...");
        statek1.ZaladujKontener(kontener1);
        statek1.ZaladujKontener(kontener2);

        Console.WriteLine("\nWyświetlamy informacje o statku 1:");
        statek1.WyswietlInformacjeOStatku();

        Console.WriteLine("\nZaładunek listy kontenerów na statek 2...");
        List<Kontener> listaKontenerow = new List<Kontener> { kontener3, kontener4 };
        statek2.ZaladujListeKontenerow(listaKontenerow);

        Console.WriteLine("\nWyświetlamy informacje o statku 2:");
        statek2.WyswietlInformacjeOStatku();

        Console.WriteLine("\nUsuwamy kontener z numerem seryjnym " + kontener2.numerseryjny + " ze statku 1...");
        statek1.RozladujKontener(kontener2.numerseryjny);
        statek1.WyswietlInformacjeOStatku();

        Console.WriteLine("\nRozładowujemy ładunek z kontenera " + kontener1.numerseryjny + "...");
        kontener1.Oproznij();
        Console.WriteLine($"Po rozładowaniu: {kontener1}");

        Console.WriteLine("\nZastępujemy kontener na statku 1 nowym kontenerem...");
        statek1.ZamienKontener(kontener1.numerseryjny, kontener4);
        statek1.WyswietlInformacjeOStatku();

        Console.WriteLine("\nPrzenosimy kontener z numerem " + kontener4.numerseryjny + " ze statku 1 na statek 2...");
        statek1.PrzeniesKontener(kontener4.numerseryjny, statek2);
        Console.WriteLine("\nWyświetlamy informacje o statkach po przeniesieniu:");
        statek1.WyswietlInformacjeOStatku();
        statek2.WyswietlInformacjeOStatku();
    }
}


