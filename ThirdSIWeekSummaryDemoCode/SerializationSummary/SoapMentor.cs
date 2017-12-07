using System;

namespace SerializationSummary
{
    [Serializable]
    public class SoapMentor
    {
        // A public field.
        public bool IsActiveMentor = true;

        // A private field.
        private int _personAge = 21;

        // Public property/private data.
        private string _firstName = string.Empty;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
    }
}
