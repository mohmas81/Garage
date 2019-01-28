using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage_1._0
{
    public class GarageCreator {
         Garage<Vehicle> garage;
         GarageHandler garageHandler = new GarageHandler();
        private  Dictionary<ConsoleKey, Action> parkVehicle;



        internal void Run()
        {
            while (true)
            {
                //Console.Clear();
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 0) of your choice\n"
                    + "\n1. Create a Garage with expected capacity"
                    + "\n2. Garage Functions"
                    + "\n3. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':

                        garage = CreateGarage();
                        break;
                    case '2':

                        GarageFunctions(garage);
                        break;

                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '3':
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }

        }


        public void GarageFunctions(Garage<Vehicle> garage)
        {
            Console.Clear();
            if (garage != null)
            {
                while (true)

                {

                    Console.WriteLine("Please navigate through the menu by inputting your choice:\n"
                        + "\n 1: Print out all parked vehicles "
                        + "\n 2: Print out types of vehicles and number of each that exsist in Garage"
                        + "\n 3: Park a vehicle in Garage"
                        + "\n 4: Take out a vehicle from Garage"
                        + "\n 5: Find a vehicle with registering number"
                        + "\n 6: Find vehicles with specific properties"
                        + "\n 7: Garage capacity."
                        + "\n 8: Back to main Menu"
                        );

                    char input = ' '; //Creates the character input to be used with the switch-case below.

                    try
                    {
                        input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                    }
                    catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter some input!");
                    }

                    switch (input)
                    {
                        case '1':

                            PrintOutAllVehicles();
                            break;

                        case '2':

                            VehicleTypeNumbers();
                            break;

                        case '3':

                            ParkVehicle();
                            break;

                        case '4':

                            TakeOutVehicle();
                            break;

                        case '5':

                            FindByRegNumber();
                            break;

                        case '6':

                            FindByProperties();
                            break;

                        case '7':

                            Console.WriteLine($"There is {GarageEmptyPlace(garage)} empty place in garage");
                            break;

                        case '8':
                            return;
                        default:
                            Console.WriteLine("Please enter some valid input ( 1, 2, 3, 4, 5, 6, 7 )");
                            break;
                    }
                }
            }
            else
                Console.WriteLine("You should first create a garage then use its functions.");
        }

        public int GarageEmptyPlace(Garage<Vehicle> garage)
        {
            Console.Clear();
            if (garage != null)
            {
                return garage.Capacity - garage.Count;
            }
            else
                return 0;
        }

        public void FindByProperties()
        {
            Console.Clear();

            if (garage.Count > 0)
            {

                List<Vehicle> result = new List<Vehicle>();
                int noOfWheel;
                bool success;

                Console.WriteLine("Please enter the common property of vehicles, leave it empty if is not important ");

                Console.Write("Color? ");
                string color = Console.ReadLine();

                Console.Write("NumberOfWheels? ");
                string noOfWheelstring = Console.ReadLine();

                if (string.IsNullOrEmpty(color) && string.IsNullOrEmpty(noOfWheelstring))
                {
                    return;
                }




                if (string.IsNullOrEmpty(color))
                {
                    do
                    {
                        success = int.TryParse(noOfWheelstring, out noOfWheel);
                        if (!success || noOfWheel < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong format, only numbers accepted.");
                            Console.WriteLine("NumberOfWheels? ");
                            noOfWheelstring = Console.ReadLine();

                            if (string.IsNullOrEmpty(noOfWheelstring))
                                return;
                        }

                    } while (!success || noOfWheel < 0);

                    result = garage.Where(v => v.NoWheel == noOfWheel).ToList();

                }

                if (string.IsNullOrEmpty(noOfWheelstring))
                {
                    result = garage.Where(v => v.Color == color.ToUpper() || v.Color == color.ToLower()).ToList();

                }

                if (!string.IsNullOrEmpty(color) && !string.IsNullOrEmpty(noOfWheelstring))
                {
                    do
                    {
                        success = int.TryParse(noOfWheelstring, out noOfWheel);
                        if (!success)
                        {
                            Console.WriteLine("Wrong format, only numbers accepted.");
                            Console.WriteLine("NumberOfWheels? ");
                            noOfWheelstring = Console.ReadLine();
                        }
                    } while (!success);

                    result = garage.Where(v => v.NoWheel == noOfWheel && v.Color.ToLower() == color.ToLower()).ToList();
                }

                if (result.Count > 0)
                {
                    foreach (var item in result)
                    {
                        //Console.Clear();
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine($"There is not any parked car with expected information.");
                }

            }
            else
            {
                Console.WriteLine("Garage is empty.");
            }


        }

        public void FindByRegNumber()
        {
            string regNumber;

            Console.Clear();
            if (garage.Count > 0)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Enter Reg.Number:");
                    regNumber = Console.ReadLine();
                } while (string.IsNullOrEmpty(regNumber));

                Vehicle vehicle = FindByRegNumber(garage,regNumber);

                if (vehicle != null)
                    Console.WriteLine(vehicle);
                else
                    Console.WriteLine($"Car with Reg.Number {regNumber} has not been parked in garage.\n");

            }
            else
            {
                Console.WriteLine("Garage is empty.");
            }

        }

        public Vehicle FindByRegNumber(Garage<Vehicle> garage,string regNumber)
        {
            try
            {
                var vehicle = garage.Where(v => v.RegisteringNumber == regNumber.ToLower() || v.RegisteringNumber == regNumber.ToUpper()).First();

                return vehicle;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public void TakeOutVehicle()
        {
            string regNumber;
            bool success;

            Console.Clear();
            if (garage.Count > 0)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Enter Reg.Number:");
                    regNumber = Console.ReadLine();
                } while (string.IsNullOrEmpty(regNumber));

                success = TakeOutVehicle(garage, regNumber);


                if (success)
                {
                    Console.Clear();
                    Console.WriteLine($"Car with Reg.Number {regNumber} drived out from garage.\n");
                }
                else              
                {
                    Console.Clear();
                    Console.WriteLine($"Car with Reg.Number {regNumber} has not been parked in garage.\n");
                }
            }
            else
            {
                Console.WriteLine("Garage is empty");
            }
        }

        public bool TakeOutVehicle(Garage<Vehicle> garage, string regNumber)
        {
            try
            {
                var vehicle = garage.Where(v => v.RegisteringNumber == regNumber.ToLower() || v.RegisteringNumber == regNumber.ToUpper()).First();
                return garageHandler.RemoveVehicle(garage, vehicle);
                
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void ParkVehicle()
        {
            if (!garage.IsFull)
            {
                parkVehicle = new Dictionary<ConsoleKey, Action>
            {
                { ConsoleKey.Q, Quit },
                { ConsoleKey.C, ParkCar },
                { ConsoleKey.B, ParkBus },
                { ConsoleKey.M, ParkMC },
                { ConsoleKey.A, ParkAirplane },
                {ConsoleKey.S, ParkBoat },

                    
               // { ConsoleKey.V, ParkVehicle },
                
            };
                bool readKey = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine("C: Car, B: Bus, M: MC, A: Airplane, S: Boat, Q: Quit");
                    var key = Console.ReadKey(intercept: true).Key;

                    if (parkVehicle.ContainsKey(key))
                    {
                        Action action = parkVehicle[key];
                        action();
                        readKey = true;
                    }
                    else
                    {
                        Console.WriteLine("Only valid keys accepted");
                        readKey = false;
                    }
                } while (!readKey);
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Garage is full, wellcomeback later! :)");
            }
        }

        public void ParkBoat()
        {
            //string regNumber;
            //string color;
            int noOfWheel;
            int cylinderVolume;
            string fuelType;
            int lenght;

            var commonProperties = VehicleProperties();

            noOfWheel = Convert.ToInt32(commonProperties[2]);


            string cylinderVolumeString;
            bool success1;
            do
            {
                Console.Clear();
                Console.WriteLine("Cylinder Volume: ");
                cylinderVolumeString = Console.ReadLine();
                success1 = int.TryParse(cylinderVolumeString, out cylinderVolume);

                if (!success1 || cylinderVolume < 0)
                {
                    Console.WriteLine("Only valid numbers accepted.");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(cylinderVolumeString) || !success1 || cylinderVolume < 0);

            do
            {
                Console.Clear();
                Console.WriteLine("Type of fuel: ");
                fuelType = Console.ReadLine();
            } while (string.IsNullOrEmpty(fuelType));

            string noOfEngineString;
            bool success2;
            do
            {
                Console.Clear();
                Console.WriteLine("Number of engine ");
                noOfEngineString = Console.ReadLine();
                success2 = int.TryParse(noOfEngineString, out lenght);

                if (!success2 || lenght < 0)
                {
                    Console.WriteLine("Only valid numbers accepted.");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(noOfEngineString) || !success2 || lenght < 0);

            garageHandler.ParkBoat(garage, commonProperties[0], commonProperties[1], noOfWheel, cylinderVolume, fuelType, lenght);

        }

        public void ParkAirplane()
        {
            #region
            //Console.WriteLine("Enter Airplane information:  RegisteringNumber Color NoWheel Type");

            //string airplaneInfo = Console.ReadLine();
            //string[] result = airplaneInfo.Split(' ');

            //int noWheel = Convert.ToInt32(result[2]);


            //garageHandler.ParkAirplane(garage, result[0], result[1], noWheel, result[3]);
            #endregion

            // string regNumber;
            //string color;
            int noOfWheel;
            string type;

            #region
            //Console.Clear();
            //do
            //{
            //    Console.Clear();
            //    Console.WriteLine("RegisterNumber: ");
            //    regNumber = Console.ReadLine();
            //} while (string.IsNullOrEmpty(regNumber));

            //do
            //{
            //    Console.Clear();
            //    Console.WriteLine("Color: ");
            //    color = Console.ReadLine();
            //} while (string.IsNullOrEmpty(color));

            //string noOfWheelString;
            //bool success;
            //do
            //{
            //    Console.Clear();
            //    Console.WriteLine("Number of wheels: ");
            //    noOfWheelString = Console.ReadLine();
            //    success = int.TryParse(noOfWheelString, out noOfWheel);
            //    if (!success || noOfWheel < 0)
            //    {
            //        Console.WriteLine("Only valid numbers accepted. ");
            //        Console.ReadLine();
            //    }

            //} while (string.IsNullOrEmpty(noOfWheelString) || !success || noOfWheel < 0);
            #endregion

            var commonProperties = VehicleProperties();

            do
            {
                Console.Clear();
                Console.WriteLine("Type of Airplane: ");
                type = Console.ReadLine();
            } while (string.IsNullOrEmpty(type));

            noOfWheel = Convert.ToInt32(commonProperties[2]);
            garageHandler.ParkAirplane(garage, commonProperties[0], commonProperties[1], noOfWheel, type);

        }

        public void ParkMC()
        {
            #region
            //Console.Clear();
            //Console.WriteLine("Enter MC information:  RegisteringNumber Color NoWheel CylinderVolume FuelType");

            //string mcInfo = Console.ReadLine();
            //string[] result = mcInfo.Split(' ');

            //int noWheel = Convert.ToInt32(result[2]);
            //int cylinderVolume = Convert.ToInt32(result[3]);

            //garageHandler.ParkMC(garage, result[0], result[1], noWheel, cylinderVolume, result[4]);
            #endregion

            //string regNumber;
            //string color;
            int noOfWheel;
            int cylinderVolume;
            string fuelType;


            var commonProperties = VehicleProperties();

            noOfWheel = Convert.ToInt32(commonProperties[2]);


            string cylinderVolumeString;
            bool success1;
            do
            {
                Console.Clear();
                Console.WriteLine("Cylinder Volume: ");
                cylinderVolumeString = Console.ReadLine();
                success1 = int.TryParse(cylinderVolumeString, out cylinderVolume);

                if (!success1 || cylinderVolume < 0)
                {
                    Console.WriteLine("Only valid numbers accepted.");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(cylinderVolumeString) || !success1 || cylinderVolume < 0);

            do
            {
                Console.Clear();
                Console.WriteLine("Type of fuel: ");
                fuelType = Console.ReadLine();
            } while (string.IsNullOrEmpty(fuelType));


            garageHandler.ParkMC(garage, commonProperties[0], commonProperties[1], noOfWheel, cylinderVolume, fuelType);


        }

        public void ParkBus()
        {

            #region
            //Console.Clear();
            //Console.WriteLine("Enter bus information:  RegisteringNumber Color NoWheel CylinderVolume FuelType NoOfSeats\n");
            //string busInfo = Console.ReadLine();
            //string[] result = busInfo.Split(' ');

            //int noWheel = Convert.ToInt32(result[2]);
            //int cylinderVolume = Convert.ToInt32(result[3]);
            //int NoOfSeats = Convert.ToInt32(result[5]);

            //garageHandler.ParkBus(garage, result[0], result[1], noWheel, cylinderVolume, result[4], NoOfSeats);
            #endregion

            //string regNumber;
            //string color;
            int noOfWheel;
            int cylinderVolume;
            string fuelType;
            int noOfSeats;

            var commonProperties = VehicleProperties();
            noOfWheel = Convert.ToInt32(commonProperties[2]);


            string cylinderVolumeString;
            bool success1;
            do
            {
                Console.Clear();
                Console.WriteLine("Cylinder Volume: ");
                cylinderVolumeString = Console.ReadLine();
                success1 = int.TryParse(cylinderVolumeString, out cylinderVolume);

                if (!success1 || cylinderVolume < 0)
                {
                    Console.WriteLine("Only valid numbers accepted.");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(cylinderVolumeString) || !success1 || cylinderVolume < 0);

            do
            {
                Console.Clear();
                Console.WriteLine("Type of fuel: ");
                fuelType = Console.ReadLine();
            } while (string.IsNullOrEmpty(fuelType));

            string noOfEngineString;
            bool success2;
            do
            {
                Console.Clear();
                Console.WriteLine("Number of engine ");
                noOfEngineString = Console.ReadLine();
                success2 = int.TryParse(noOfEngineString, out noOfSeats);

                if (!success2 || noOfSeats < 0)
                {
                    Console.WriteLine("Only valid numbers accepted.");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(noOfEngineString) || !success2 || noOfSeats < 0);

            garageHandler.ParkBus(garage, commonProperties[0], commonProperties[1], noOfWheel, cylinderVolume, fuelType, noOfSeats);


        }

        public void ParkCar()
        {
            #region
            //Console.WriteLine("Enter car information:  RegisteringNumber Color NoWheel CylinderVolume FuelType NoOfEngines\n");
            //string carInfo = Console.ReadLine();
            //string[] result = carInfo.Split(' ');

            //int noWheel = Convert.ToInt32(result[2]);
            //int cylinderVolume = Convert.ToInt32(result[3]);
            //int noOfEngines = Convert.ToInt32(result[5]);
            //garageHandler.ParkCar(garage,result[0], result[1], noWheel, cylinderVolume, result[4], noOfEngines);
            #endregion

            //string regNumber;
            //string color;
            int noOfWheel;
            int cylinderVolume;
            string fuelType;
            int noOfEngines;

            var commonProperties = VehicleProperties();

            noOfWheel = Convert.ToInt32(commonProperties[2]);


            string cylinderVolumeString;
            bool success1;
            do
            {
                Console.Clear();
                Console.WriteLine("Cylinder Volume: ");
                cylinderVolumeString = Console.ReadLine();
                success1 = int.TryParse(cylinderVolumeString, out cylinderVolume);

                if (!success1 || cylinderVolume < 0)
                {
                    Console.WriteLine("Only valid numbers accepted.");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(cylinderVolumeString) || !success1 || cylinderVolume < 0);

            do
            {
                Console.Clear();
                Console.WriteLine("Type of fuel: ");
                fuelType = Console.ReadLine();
            } while (string.IsNullOrEmpty(fuelType));

            string noOfEngineString;
            bool success2;
            do
            {
                Console.Clear();
                Console.WriteLine("Number of engine ");
                noOfEngineString = Console.ReadLine();
                success2 = int.TryParse(noOfEngineString, out noOfEngines);

                if (!success2 || noOfEngines < 0)
                {
                    Console.WriteLine("Only valid numbers accepted.");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(noOfEngineString) || !success2 || noOfEngines < 0);

            garageHandler.ParkCar(garage, commonProperties[0], commonProperties[1], noOfWheel, cylinderVolume, fuelType, noOfEngines);


        }

        public void Quit()
        {
            return;
        }

        public void VehicleTypeNumbers()
        {
            if (garage.Count > 0)
            {
                Console.Clear();
                var result = garage.GroupBy(g => g.GetType().Name)
                    .Select(f => new { Total = f.Count(), VehicleType = f.Key.ToString() });

                Console.Clear();
                foreach (var item in result)
                {
                    Console.WriteLine($"There is {item.Total}  {item.VehicleType} in Garage: ");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Garage is empty.");
            }
        }

        public void PrintOutAllVehicles()
        {
            Console.Clear();
            if (garage.Count > 0)
            {
                foreach (var item in garage)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The garage is empty.");
            }
        }

        public Garage<Vehicle> CreateGarage()
        {

            bool success;
            int capacity;
            Console.Clear();
            do // Repetera ...
            {
                Console.Write("Please enter the capacity of Garage:");
                string capacityString = Console.ReadLine();

                success = int.TryParse(capacityString, out capacity);
                if (!success || capacity <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nWrong format, only valid numbers can use \n");

                }
            } while (!success || capacity <= 0);


            var garage = garageHandler.CreateGarage(capacity);
            return garage;


        }

        public string[] VehicleProperties()
        {
            string regNumber;
            string color;
            string[] commonProperties;

            Console.Clear();
            do
            {
                Console.Clear();
                Console.WriteLine("RegisterNumber: ");
                regNumber = Console.ReadLine();
            } while (string.IsNullOrEmpty(regNumber));

            do
            {
                Console.Clear();
                Console.WriteLine("Color: ");
                color = Console.ReadLine();
            } while (string.IsNullOrEmpty(color));

            string noOfWheelString;
            bool success;
            int noOfWheel;
            do
            {
                Console.Clear();
                Console.WriteLine("Number of wheels: ");
                noOfWheelString = Console.ReadLine();
                success = int.TryParse(noOfWheelString, out noOfWheel);
                if (!success || noOfWheel < 0)
                {
                    Console.WriteLine("Only valid numbers accepted. ");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(noOfWheelString) || !success || noOfWheel < 0);


            commonProperties = new string[] { regNumber, color, noOfWheelString };
            return commonProperties;

        }

    }
}
