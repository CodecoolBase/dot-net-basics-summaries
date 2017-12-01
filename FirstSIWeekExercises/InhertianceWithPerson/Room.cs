namespace InheritanceWithPerson
{
    class Room
    {
        private int _number;

        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }

        public Room(int number)
        {
            this._number = number;
        }
    }
}
