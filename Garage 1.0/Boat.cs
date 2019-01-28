namespace Garage_1._0
{
    class Boat : Vehicle
    {      

        public int CylinderVolume
        {
            get;
            set;
        }

        public string FuelType
        {
            get;
            set;
        }

        public int Lenght
        {
            get;
            set;
        }

        public Boat(string registeringNumber, string color, int noWheel, int cylinderVolume, string fuelType, int lenght)
           : base(registeringNumber, color, noWheel)
        {
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
            Lenght = lenght;
        }

        public override string ToString()
        {
            return "Boat: " + RegisteringNumber + ", " + Color + ", " + NoWheel + ", " + CylinderVolume + ", " + FuelType + ", " + Lenght;
        }
    }
}