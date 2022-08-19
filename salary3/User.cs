namespace WorkWithData
{
    class User
    {
        public User(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; private set; }
        public double Salary { get; set; }
    }
}
