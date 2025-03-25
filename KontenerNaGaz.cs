namespace APBD;

class KontenerNaGaz : Kontener
{
    public double cisnienie  { get; }

    public KontenerNaGaz(double maxWaga, double waga, double wysokosc, double glebokosc, double cisnienie)
        : base("G", maxWaga, waga, wysokosc, glebokosc)
    {
        this.cisnienie  = cisnienie;
        Console.WriteLine($"KontenerNaGaz sworzony {numerSeryjny}");
    }

    public override void ZaładujTowar(double waga)
    {
        if (waga > maxWaga)
        {
            throw new OverfillException($"Proba zaladowania z byt duzej wagi");
        }
        
        Console.WriteLine($"Zaladowany towar do {numerSeryjny} wagi {waga}");

        wagaLadunku = waga;
    }

    public override void RozładujTowar()
    {
        wagaLadunku *= 0.05;
        
        Console.WriteLine($"Rozladowany towar z {numerSeryjny}");
    }
}