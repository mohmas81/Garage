namespace Garage_1._0
{
    class Bus : Vehicle
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


        public int NoOfSeats
        {
            get;
            set;
        }

        public Bus(string registeringNumber, string color, int noWheel, int cylinderVolume, string fuelType, int noOfSeats)
            : base(registeringNumber, color, noWheel)
        {
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
            NoOfSeats = noOfSeats;
        }

        public override string ToString()
        {
            return " Bus: " +RegisteringNumber + ", " + Color + ", " + NoWheel + ", " + CylinderVolume + ", " + FuelType + ", " + NoOfSeats;
        }
    }
}