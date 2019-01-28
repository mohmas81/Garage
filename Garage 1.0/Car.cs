namespace Garage_1._0
{
   public class Car : Vehicle
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
        public int NoOfEngines
        {
            get;
            set;
        }

        public Car(string registeringNumber, string color, int noWheel, int cylinderVolume, string fuelType, int noOfEngines)
            : base(registeringNumber, color, noWheel)
        {
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
            NoOfEngines = noOfEngines;
        }

        public override string ToString()
        {
            return " Car: " + RegisteringNumber + ", " + Color + ", " + NoWheel + ", " + CylinderVolume + ", " + FuelType + ", " + NoOfEngines;
        }
    }

}