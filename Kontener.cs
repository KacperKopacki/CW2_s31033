namespace APBD;

abstract class Kontener
{
    private static int licznik = 1;
    public string numerSeryjny { get; }
    public double wagaLadunku { get; set; }
    public double maxWaga { get; }
    public double waga { get; }
    public double wysokosc { get; }
    public double glebokosc { get; }

    protected Kontener(string typ, double maxWaga, double waga, double wysokosc, double glebokosc)
    {
        numerSeryjny = $"KON-{typ}-{licznik}";
        this.maxWaga = maxWaga;
        this.waga = waga;
        this.wysokosc = wysokosc;
        this.glebokosc = glebokosc;
        licznik++;
    }

    public abstract void ZaładujTowar(double waga);
    public abstract void RozładujTowar();

    public void Dane()
    {
        Console.WriteLine($"NUMER: {numerSeryjny}, MASA: {wagaLadunku}/{maxWaga}, WYSOKOSC: {wysokosc}, GLEBOKOSC: {glebokosc}");
    }
}