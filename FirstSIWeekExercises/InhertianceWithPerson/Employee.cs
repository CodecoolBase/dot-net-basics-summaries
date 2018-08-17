using System;

namespace InheritanceWithPerson
{
    class Employee : Person, ICloneable
    {
        //Auto-property
        public int Salary { get; set; }

        #region Full property with private field
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
        #endregion

        public Room Room;

        public Employee()
        {
            Room = null;
        }

        public Employee(string name, DateTime birthDate, int salary, string profession) : base(name, birthDate)
        {
            this.Salary = salary;
            this._profession = profession;
            Room = null;
        }

        public override string ToString()
        {
            return base.ToString() + $", salary: {Salary}, profession: {_profession}, room: {Room.Number}";
        }

        public object Clone()
        {
            Employee newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.Room = new Room(Room.Number);
            return newEmployee;
        }
    }
}
