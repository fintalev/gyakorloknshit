internal class Program
{
    static List<Eredmeny> eredmenyek = new List<Eredmeny>();
    private static void Main(string[] args)
    {
        StreamReader sr=  new StreamReader(@"..\..\..\src\eredmenyek.csv");
        sr.ReadLine(); // Skip the header line
        while (!sr.EndOfStream)
        {
            string sor = sr.ReadLine();
            if (sor != null && !string.IsNullOrWhiteSpace(sor))
            {
                Eredmeny eredmeny = new Eredmeny(sor);
                eredmenyek.Add(eredmeny);
            }
        }
        Console.WriteLine(eredmenyek.Count);
    }
}

class Eredmeny
{
    public string hazai { get; set; }
    public string idegen { get; set; }
    public int hazai_pont { get; set; }
    public int idegen_pont { get; set; }
    public string helyszin { get; set; }
    public string idopont { get; set; }

    public Eredmeny(string sor)
    {
        string[] darab = sor.Split(';');

        this.hazai = darab[0];
        this.idegen = darab[1];
        this.hazai_pont = int.Parse(darab[2]);
        this.idegen_pont = int.Parse(darab[3]);
        this.helyszin = darab[4];
        this.idopont = darab[5];
    }
}