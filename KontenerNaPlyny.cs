namespace APBD;

class KontenerNaPlyny : Kontener, IHazardNotifier
{
    public bool IsHazardous { get; }

    public KontenerNaPlyny(double maxWaga, double waga, double wysokosc, double glebokosc, bool isHazardous)
        : base("P", maxWaga, waga, wysokosc, glebokosc)
    {
        IsHazardous = isHazardous;
        Console.WriteLine($"KontenerNaPlyny sworzony {numerSeryjny}");
    }

    public override void ZaładujTowar(double waga)
    {
        double MozliwaWaga = 0;
        if (IsHazardous)
        {
            MozliwaWaga = maxWaga * 0.5;
        }
        else
        {
            MozliwaWaga = maxWaga * 0.9;
        }
        Console.WriteLine($"Zaladowany towar do {numerSeryjny} wagi {waga}");
        Console.WriteLine($"Mozliwa waga: {MozliwaWaga}");

        if (MozliwaWaga < waga)
        {
            Powiadomienie("proba zaladowania za duzego ladunku");
            throw new OverfillException("Proba zaladowania za duzego ladunku");
        }

        wagaLadunku = waga;
    }

    public override void RozładujTowar()
    {
        wagaLadunku = 0;
        
        Console.WriteLine($"Rozladowany towar z {numerSeryjny}");
    }

    public void Powiadomienie(string komunikat)
    {
        Console.WriteLine($"{komunikat}, {numerSeryjny}");
    }
}