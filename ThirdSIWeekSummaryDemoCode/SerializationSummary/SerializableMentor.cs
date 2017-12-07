using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SerializationSummary
{
    [Serializable]
    public class SerializableMentor : IDeserializationCallback
    {
        public string Name { get; set; }

        [NonSerialized]
        public int DailyCoffeeNeed;

        public List<string> Specialities { get; set; }

        [OptionalField]
        public List<string> SpokenLanguages;

        public override string ToString()
        {
            var representation = new StringBuilder();
            representation.AppendFormat("Name: {0}\n", Name);
            representation.AppendLine(DailyCoffeeNeed + " coffee needed a day.");
            representation.AppendLine("Specialities:");

            foreach (var speciality in Specialities)
            {
                representation.AppendLine("\t" + speciality);
            }
            return representation.ToString();
        }

        public void OnDeserialization(object sender)
        {
            Console.WriteLine("!!! Please make a coffee for " + Name + " !!!");
        }
    }
}
