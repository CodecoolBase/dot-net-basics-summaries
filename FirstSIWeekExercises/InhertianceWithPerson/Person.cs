using System;

namespace InheritanceWithPerson
{
    class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        internal Genders Gender { get => gender; set => gender = value; }
        private Genders gender;

        public Person()
        {

        }

        public Person(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public enum Genders : int { Male, Female };


        public override string ToString()
        {
            return $"name: {this.Name}, birthdate: {this.BirthDate}";
        }
    }
}
