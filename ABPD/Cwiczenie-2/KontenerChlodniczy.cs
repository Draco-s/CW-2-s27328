namespace Cwiczenie_2;

public class KontenerChlodniczy : Kontener
{
    public string RodzajProduktu { get; private set; }
    public double Temperatura { get; private set; }
    private static Dictionary<string, double> minimalneTemperatury = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausage", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19}
    };

    public KontenerChlodniczy(double masaladunku, double wysokosc, double wagawlasnakontenera, double glebokosc, string rodzajProduktu, double temperatura)
        : base(masaladunku, wysokosc, wagawlasnakontenera, glebokosc)
    {
        if (!minimalneTemperatury.ContainsKey(rodzajProduktu))
        {
            throw new ArgumentException($"Nieobsługiwany rodzaj produktu: {rodzajProduktu}");
        }

        if (temperatura > minimalneTemperatury[rodzajProduktu])
        {
            throw new ArgumentException($"Temperatura {temperatura}°C jest za wysoka dla {rodzajProduktu}. Wymagana: {minimalneTemperatury[rodzajProduktu]}°C lub niższa.");
        }

        RodzajProduktu = rodzajProduktu;
        Temperatura = temperatura;
    }

    public void ZaladujProdukt(double masa, string produkt)
    {
        if (produkt != RodzajProduktu)
        {
            throw new InvalidOperationException($"Kontener przechowuje tylko {RodzajProduktu}, nie można załadować {produkt}!");
        }

        base.Zaladuj(masa);
    }

    public void UstawTemperature(double nowaTemperatura)
    {
        if (nowaTemperatura > minimalneTemperatury[RodzajProduktu])
        {
            throw new InvalidOperationException($"Nie można ustawić {nowaTemperatura}°C, minimalna wymagana temperatura dla {RodzajProduktu} to {minimalneTemperatury[RodzajProduktu]}°C.");
        }

        Temperatura = nowaTemperatura;
    }
}