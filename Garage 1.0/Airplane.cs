namespace Garage_1._0
{
    class Airplane : Vehicle
    {

        public string Type // Bouing, Airbas, ...
        {
            get;
            set;
        }

        public Airplane(string registeringNumber, string color, int noWheel, string type) : base (registeringNumber, color, noWheel)
        {
            Type = type;   
        }

        public override string ToString()
        {
            return " Airplane: " + RegisteringNumber + ", " + Color + ", " + NoWheel + ", " + Type ;
        }
    }

}