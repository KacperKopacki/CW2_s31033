using APBD;

class Program
{
    static void Main(string[] args)
    {
        Statek statek1 = new Statek("Tytanik", 30, 5, 90100);
        Statek statek2 = new Statek("Tytanik2", 30, 5, 90100);

        Kontener kon1 = new KontenerNaPlyny(50, 10, 200, 100, true);
        Kontener kon2 = new KontenerNaGaz(40, 12, 150, 80, 5);
        Kontener kon3 = new KontenerChlodniczy(30, 8, 100, 70, "Banany", 14);
        Kontener kon4 = new KontenerNaGaz(60, 12, 150, 80, 4);
        
        kon1.ZaładujTowar(25);
        kon2.ZaładujTowar(35);
        kon3.ZaładujTowar(25);
        
        statek1.ZaładujKontenerNaS(kon1);
        statek1.ZaładujKontenerNaS(kon2);
        
        statek2.ZaładujKontenerNaS(kon3);
        
        statek1.PrzeniesKontenr(statek2, "KON-P-1");
        
        kon1.Dane();
        
        statek2.ZastąpKontenerNaS("KON-P-1", kon4);

        //Kontener kon5 = new KontenerChlodniczy(20, 8, 100, 70, "Ryba", -2);
        Kontener kon6 = new KontenerChlodniczy(20, 8, 100, 70, "Ryba", 2);
        Statek statek3 = new Statek("Tytanik3", 30, 1, 10);
        kon6.ZaładujTowar(3);
        //statek3.ZaładujKontenerNaS(kon6);
        kon6.RozładujTowar();
        statek3.ZaładujKontenerNaS(kon6);
        Kontener kon7 = new KontenerChlodniczy(20, 2, 100, 70, "Ryba", 2);
        //statek3.ZaładujKontenerNaS(kon7);
        
        Statek statek4 = new Statek("Tytanik4", 35, 5, 300);
        
        List<Kontener> listaKontenerow = new List<Kontener>
        {
            new KontenerNaPlyny(50, 10, 200, 100, false),
            new KontenerNaGaz(40, 12, 150, 80, 5),
            new KontenerChlodniczy(30, 8, 100, 70, "Banany", 14),
            new KontenerNaPlyny(60, 15, 220, 120, true),
            new KontenerNaGaz(45, 11, 160, 90, 4)
        };
        
        foreach (var kontener in listaKontenerow)
        {
            kontener.ZaładujTowar(kontener.maxWaga * 0.5);
        }
        
        statek4.ZaładujKontenerNaS(listaKontenerow);
        
        statek4.WypiszDaneStatku();
    }
}