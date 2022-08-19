using Transfer;

namespace WorkWithData
{
    static class FileHandler
    {
        public static void Read(string pathReadingFile, List<User> database)
        {
            if (File.Exists(pathReadingFile))
            {
                StreamReader file = new StreamReader(pathReadingFile);
                string name;
                double salary;
                string salaryInString;
                string fileLine;

                while (!file.EndOfStream)
                {
                    fileLine = file.ReadLine();
                    name = fileLine.Substring(0, fileLine.IndexOf('\t'));

                    salaryInString = fileLine.Substring(fileLine.LastIndexOf('\t') + 1);
                    if (salaryInString.Contains("."))
                        salaryInString = salaryInString.Replace('.', ',');

                    double.TryParse(salaryInString, out salary);
                    database.Add(new User(name, salary));
                }
                file.Close();
            }
            else
                Console.WriteLine("INPUT FILE WAS NOT FOUND");
        }

        public static void Write(string pathWritingFile, List<User> database)
        {
            StreamWriter file = new StreamWriter(pathWritingFile);
            foreach (User user in database)
                file.WriteLine($"{user.Name}\t{NumberToWords.ToWords(user.Salary)}");
            file.Close();
        }
    }
}
