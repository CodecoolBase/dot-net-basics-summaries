using System;

namespace InheritanceWithPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee kovacs = new Employee("Géza", DateTime.Now, 1000, "léhűtő");
            kovacs.Room = new Room(111);
            Employee kovacs2 = (Employee)kovacs.Clone();
            kovacs2.Room.Number = 112;

            Console.WriteLine(kovacs.ToString());
            Console.WriteLine(kovacs2.ToString());
            Console.ReadKey();
        }
    }
}
