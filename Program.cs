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
		//f3
		Console.WriteLine($"Real Madrid hazai:{eredmenyek.Count(x=>x.hazai.Equals("Real Madrid"))}");
		Console.WriteLine($"Real Madrid idegen:{eredmenyek.Count(x=>x.idegen.Equals("Real Madrid"))}");
        //f4
		var dontetlenek = eredmenyek.Where(x => x.hazai_pont == x.idegen_pont).ToList();
		if (dontetlenek.Count > 0) Console.WriteLine("Volt döntetlen?: igen");
		else Console.WriteLine("Volt döntetlen?: nem");
        //f5
        Console.WriteLine($"barcelonai csapat neve:{eredmenyek.Where(x=>x.hazai.Contains("Barcelona")).FirstOrDefault().hazai}");
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