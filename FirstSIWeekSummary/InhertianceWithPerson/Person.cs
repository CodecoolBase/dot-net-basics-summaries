using System;

namespace InhertianceWithPerson
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
            return String.Format("name: {0}, birthdate: {1}", this.Name, this.BirthDate);
        }
    }
}
