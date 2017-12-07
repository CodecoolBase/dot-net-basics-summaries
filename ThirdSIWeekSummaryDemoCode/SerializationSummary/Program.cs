using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace SerializationSummary
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo01ObjectSerialization();
            Demo02ObjectDeserialization();
            Demo03SoapFomatter();
            Demo04XmlSerialization();
            Demo05CustomSerialization();
            Console.ReadKey();
        }

        public static void Demo01ObjectSerialization()
        {
            var mentor = GetSerializableMentor();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("superMentor.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, mentor);
            Console.WriteLine("Serialization was successful!");
            Console.WriteLine(mentor);

            stream.Close();
        }
        
        public static void Demo02ObjectDeserialization()
        {
            IFormatter formatter = new BinaryFormatter();

            Console.WriteLine("Give me the name of the serialized file and hit ENTER: ");
            var fileName = Console.ReadLine();

            try
            {
                Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                SerializableMentor mentor = (SerializableMentor)formatter.Deserialize(stream);
                stream.Close();
                Console.WriteLine(mentor);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine(ioEx.Message);
                Console.WriteLine("Maybe you misstyped the filename!");
            }

        }

        public static void Demo03SoapFomatter()
        {
            // Save object to a file named soapMentor.soap in SOAP format.
            SoapFormatter soapFormat = new SoapFormatter();
            var mentor = new SoapMentor
            {
                FirstName = "Soa Peter",
                IsActiveMentor = true
            };

            using (Stream fStream = new FileStream("soapMentor.soap",
                                                    FileMode.Create,
                                                    FileAccess.Write,
                                                    FileShare.None))
            {
                soapFormat.Serialize(fStream, mentor);
            }

            Console.WriteLine("=> Saved soap mentor in SOAP format!");
            Console.WriteLine("What does happen when you try to serialize an object\nwith generic type via SoapFormatter???");
        }

        public static void Demo04XmlSerialization()
        {
            var mentor = GetSerializableMentor();
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(SerializableMentor));

            using (Stream stream = new FileStream("mentor.xml",
                                                FileMode.Create,
                                                FileAccess.Write))
            {
                xmlFormatter.Serialize(stream, mentor);
            }

            Console.WriteLine("Mentor data saved into XML. Jupyyyy!");
        }

        public static void Demo05CustomSerialization()
        {
            /*
            ISerializable interface
            GetObjectData(SerializationInfo, StreamingContext)
            SerializationInfo.AddValue(key, value)
            Special constructor
            constrName(SerializationInfo, StreamingContext)
            Info.GetXXX(”key”)
            Local System privileges [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter= true)]
            */
        }

        private static SerializableMentor GetSerializableMentor()
        {
            var mentor = new SerializableMentor
            {
                Name = "SuperMentor",
                Specialities = new List<string>
                {
                    "C#",
                    "Java",
                    "Python",
                    "Mentor++"
                },
                DailyCoffeeNeed = 3
            };
            return mentor;
        }
    }
}
