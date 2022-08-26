using Transfer;
using WorkWithData;
using System.Configuration;
using salary3;

class Master
{
    public static void Main(string[] args)
    {
        
        Settings settings = new Settings();

        foreach (var pair in settings)
        {
            Console.WriteLine(pair);
        }

        if (args.Length > 0)
        { 
            string customConfig = args[0];
            settings.AddConfigFile(customConfig);
        }

        string inputFile = settings.GetSetting("SourceFile");
        string outputFile = settings.GetSetting("DestFile");
        string bonus = settings.GetSetting("BonusPercent");       
        
        var database = new List<User>();
        FileHandler.Read(inputFile, database);

        //Console.Write("Enter premium rate in percent format:\t");
        //int premium = int.Parse(Console.ReadLine());

        int premium = int.Parse(bonus);
        

        foreach (var i in database)
            i.Salary *= ((double)premium / 100 + 1);

        FileHandler.Write(outputFile, database);
    }

}