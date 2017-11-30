using System;

namespace InheritanceWithPerson
{
    class Employee : Person, ICloneable
    {
        private int _salary;

        public int Salary
        {
            get
            {
                return _salary;
            }

            set
            {
                _salary = value;
            }
        }

        private string _profession;

        public string Profession
        {
            get
            {
                return _profession;
            }

            set
            {
                _profession = value;
            }
        }

        public Room Room;

        public Employee()
        {
            Room = null;
        }

        public Employee(string name, DateTime birthDate, int salary, string profession) : base(name, birthDate)
        {
            this._salary = salary;
            this._profession = profession;
            Room = null;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", salary: {0}, profession: {1}, room: {2}", _salary, _profession, Room.Number);
        }

        public object Clone()
        {
            Employee newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.Room = new Room(Room.Number);
            return newEmployee;
        }
    }
}
