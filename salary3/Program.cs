using Transfer;
using WorkWithData;

class Master
{
    public static void Main()
    {
        Console.Write("Enter input file path:\t");
        string inputFile = Console.ReadLine();
        Console.Write("Enter output file path:\t");
        string outputFile = Console.ReadLine();
        

        var database = new List<User>();
        FileHandler.Read(inputFile, database);

        Console.Write("Enter premium rate in percent format:\t");
        int premium = int.Parse(Console.ReadLine());

        foreach (var i in database)
            i.Salary *= ((double)premium / 100 + 1);

        FileHandler.Write(outputFile, database);
    }
}