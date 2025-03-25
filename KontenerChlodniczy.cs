namespace APBD;

class KontenerChlodniczy : Kontener
{
    private static readonly Dictionary<string, double> temperatury = new()
    {
        { "Banany", 13.3 }, { "Czekolada", 18 }, { "Ryba", 2 }, { "Mieso", -15 },
        { "Lody", -18 }, { "Mrozona Pizza", -30 }, { "Ser", 7.2 }, { "Kielbasa", 5 }, { "Maslo", 20.5 }, { "Jajka", 19 }
    };
    
    public string typProduktu { get; }
    public double temperatura { get; }

    public KontenerChlodniczy(double maxwaga, double waga, double wysokosc, double glebokosc, string typProduktu,
        double temperatura)
        : base("C", maxwaga, waga, wysokosc, glebokosc)
    {
        if (!temperatury.ContainsKey(typProduktu) || temperatura < temperatury[typProduktu])
        {
            throw new Exception(
                "Temperatura jest zla dla danego produktu lub nie mozna tego produktu miec w tym kontenerze");
        }
        this.typProduktu = typProduktu;
        this.temperatura= temperatura;
        Console.WriteLine($"KontenerChlodniczy na {typProduktu} stworzony {numerSeryjny}");
    }

    public override void ZaładujTowar(double waga)
    {
        if (waga > maxWaga)
        {
            throw new OverfillException("Proba zaladowania za duzego ladunku");
        }
        
        Console.WriteLine($"Zaladowany towar do {numerSeryjny} wagi {waga}");

        wagaLadunku = waga;
    }

    public override void RozładujTowar()
    {
        wagaLadunku = 0;
        
        Console.WriteLine($"Rozladowany towar z {numerSeryjny}");
    }
}