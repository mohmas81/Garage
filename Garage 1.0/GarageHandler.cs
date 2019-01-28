using System;

namespace Garage_1._0
{
    public class GarageHandler
    {
        public Garage<Vehicle> CreateGarage(int capacity)
        {
            var garage = new Garage<Vehicle>(capacity);

            Console.WriteLine($"\nYour garage with capacity: {capacity} vehicles has been created successfully " +
                $" now you can use its functions\n");
            return garage;
        }


        public bool RemoveVehicle(Garage<Vehicle> garage, Vehicle vehicle)
        {
            return (garage.Remove(vehicle));
        }

        public bool ParkBoat(Garage<Vehicle> garage, string registeringNumber, string color, int noWheel, int cylinderVolume, string fuelType, int lenght)
        {
            var boat = new Boat(registeringNumber, color, noWheel, cylinderVolume, fuelType, lenght);
            if (garage.Add(boat))
            {
                Console.WriteLine($"\n{registeringNumber} has been parked to garage successfully.\n");
                return true;
            }
            else
                return false;
        }

        public bool ParkBus(Garage<Vehicle> garage, string registeringNumber, string color, int noWheel, int cylinderVolume, string fuelType, int noOfSeats)
        {
            var bus = new Bus(registeringNumber, color, noWheel, cylinderVolume, fuelType, noOfSeats);
            if (garage.Add(bus))
            {
                Console.WriteLine($"\n{registeringNumber} has been parked to garage successfully.\n");
                return true;
            }
            else
                return false;
        }

        public bool ParkMC(Garage<Vehicle> garage, string registeringNumber, string color, int noWheel, int cylinderVolume, string fuelType)
        {
            var mc = new Motorcycle(registeringNumber, color, noWheel, cylinderVolume, fuelType);
            if (garage.Add(mc))
            {
                Console.WriteLine($"\n{registeringNumber} has been parked to garage successfully.\n");
                return true;
            }
            else
                return false;
        }

        public bool ParkAirplane(Garage<Vehicle> garage, string registeringNumber, string color, int noWheel, string type)
        {
            var airplane = new Airplane(registeringNumber, color, noWheel, type);
            if (garage.Add(airplane))
            {
                Console.WriteLine($"\n{registeringNumber} has been parked to garage successfully.\n");
                return true;
            }
            else
                return false;

        }

        public bool ParkCar(Garage<Vehicle> garage, string regNumber, string color, int noOfWheel, int cylinderVolume, string fuelType, int noOfEngines)
        {
            var car = new Car(regNumber, color, noOfWheel, cylinderVolume, fuelType, noOfEngines);
            if (garage.Add(car))
            {
                Console.WriteLine($"\n{regNumber} has been parked to garage successfully.\n");
                return true;
            }
            else
                return false;
        }

    }

}

