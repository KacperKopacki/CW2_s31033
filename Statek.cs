namespace APBD;

class Statek
{
    public string nazwa { get; }
    public double MaxPredkosc { get; }
    public int MaxKontenerow { get; }
    public double MaxWaga { get; }
    private List<Kontener> kontenery;

    public Statek(string nazwa, double MaxPredkosc, int MaxKontenerow, double MaxWaga)
    {
        this.nazwa = nazwa;
        this.MaxPredkosc = MaxPredkosc;
        this.MaxKontenerow = MaxKontenerow;
        this.MaxWaga = MaxWaga;
        this.kontenery = new List<Kontener>();
        Console.WriteLine($"Statek stworzony: {nazwa}");
    }

    private double WszystkeWagi()
    {
        double w = 0;
        foreach (var k in kontenery)
        {
            w += k.waga + k.wagaLadunku;
        }
        return w;
    }

    public void ZaładujKontenerNaS(Kontener kontener)
    {
        if (kontenery.Count >= MaxKontenerow || WszystkeWagi() + kontener.wagaLadunku + kontener.waga > MaxWaga)
        {
            throw new Exception("nie da sie zaladowac tego konteneru");
        }
        Console.WriteLine($"Zaldowany kontener {kontener.numerSeryjny}, na statek {nazwa}");
        kontenery.Add(kontener);
    }

    public void ZaładujKontenerNaS(List<Kontener> kontenery)
    {
        foreach (var k in kontenery)
        {
            ZaładujKontenerNaS(k);
        }
    }

    public void RozładujKontenerZS(string numerSeryjny)
    {
        kontenery.RemoveAll(k => k.numerSeryjny == numerSeryjny);
        
        Console.WriteLine($"Rozladowany kontener {numerSeryjny} z statek {nazwa}");
    }

    public void ZastąpKontenerNaS(string numerSeryjny, Kontener kontener)
    {
        RozładujKontenerZS(numerSeryjny);
        ZaładujKontenerNaS(kontener);
        
        Console.WriteLine($"Kontener {numerSeryjny} z statek {nazwa} zostal zastapiony {kontener.numerSeryjny}");
    }

    public void PrzeniesKontenr(Statek statek, string numerSeryjny)
    {
        var kontener = kontenery.Find(k => k.numerSeryjny == numerSeryjny);

        if (kontener == null)
        {
            Console.WriteLine($"nie znaleziono takiego kontenera {numerSeryjny}");
        }
        RozładujKontenerZS(numerSeryjny);
        statek.ZaładujKontenerNaS(kontener);
    }
    
    public void WypiszDaneStatku()
    {
        Console.WriteLine($"Statek: {nazwa}");
        Console.WriteLine($"Maksymalna liczba kontenerów: {MaxKontenerow}");
        Console.WriteLine($"Maksymalna waga: {MaxWaga} kg");
        Console.WriteLine($"Obecna liczba kontenerów: {kontenery.Count}");

        if (kontenery.Count == 0)
        {
            Console.WriteLine("NA statku nie ma kontenerow");
        }
    }
    
}