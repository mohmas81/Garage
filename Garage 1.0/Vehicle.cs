namespace Garage_1._0
{
    public class Vehicle
    {

        public string RegisteringNumber
        {
            get;
            set;
        }

        public string Color
        {
            get;
            set;
        }
        public int NoWheel
        {
            get;
            set;
        }

        public Vehicle(string registeringNumber, string color, int noWheel)
        {
            RegisteringNumber = registeringNumber;
            Color = color;
            NoWheel = noWheel;
        }

        public override string ToString()
        {
            return "Vehicle: " + RegisteringNumber + ", " + Color + " ," + NoWheel;
        }
    }
}