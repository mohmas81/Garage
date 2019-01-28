namespace Garage_1._0
{
    class Motorcycle : Vehicle
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

        public Motorcycle(string registeringNumber, string color, int noWheel, int cylinderVolume, string fuelType)
            : base(registeringNumber, color, noWheel)
        {
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return " Motorcycle: " + RegisteringNumber + ", " + Color + ", " + NoWheel + ", " + CylinderVolume + ", " + FuelType + ", " ;
        }
    }
}