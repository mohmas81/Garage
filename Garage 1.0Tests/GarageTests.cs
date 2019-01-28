using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage_1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage_1;

namespace Garage_1._0.Tests
{
    [TestClass()]
    public class GarageTests
    {
        

        [TestMethod()]
        public void FindByRegNumber_Succeed()
        {
            // Arrange

            var garageCreator = new GarageCreator();
            var garageHandler = new GarageHandler();
            var garage = garageHandler.CreateGarage(1);
            Car expectedCar = new Car("SWW023", "white", 4, 2000, "Diseal", 1);
            garageHandler.ParkCar(garage, "SWW023", "white", 4, 2000, "Diseal", 1);


            // Act

            Vehicle vehicle = garageCreator.FindByRegNumber(garage,"SWW023");


            // Assert
            // Find Car
            Assert.AreEqual(expectedCar.RegisteringNumber,vehicle.RegisteringNumber);
            Assert.AreEqual(expectedCar.Color, vehicle.Color);
            Assert.AreEqual(expectedCar.NoWheel, vehicle.NoWheel);



        }

        [TestMethod()]
        [Owner("Mohsen")]
        public void FindByRegNumber_NotSucceed()
        {
            // Arrange

            var garageCreator = new GarageCreator();
            var garageHandler = new GarageHandler();
            var garage = garageHandler.CreateGarage(1);
            garageHandler.ParkCar(garage, "abc123", "white", 4, 2000, "Diseal", 1);


            // Act

            Vehicle vehicle = garageCreator.FindByRegNumber(garage, "SWW023");

            // Assert

            Assert.IsNull(vehicle);

        }

        [TestMethod()]
        [Owner("Mohsen")]
        public void TakeOutVehicle_Exist_Car()
        {
            // Arrange

            var garageCreator = new GarageCreator();
            var garageHandler = new GarageHandler();
            var garage = garageHandler.CreateGarage(1);
            garageHandler.ParkCar(garage, "SWW023", "white", 4, 2000, "Diseal", 1);


            // Act

            bool success = garageCreator.TakeOutVehicle(garage, "SWW023");
            bool noSuccess = garageCreator.TakeOutVehicle(garage, "abcd123");

            // Assert

            Assert.IsTrue(success);
            Assert.IsFalse(noSuccess);
           
        }

        [TestMethod()]
        [Owner("Mohsen")]
        public void TakeOutVehicle_DoesNotExist_Car()
        {
            // Arrange

            var garageCreator = new GarageCreator();
            var garageHandler = new GarageHandler();
            var garage = garageHandler.CreateGarage(1);
            garageHandler.ParkCar(garage, "SWW023", "white", 4, 2000, "Diseal", 1);


            // Act

            bool noSuccess = garageCreator.TakeOutVehicle(garage, "abcd123");

            // Assert

            Assert.IsFalse(noSuccess);

        }

        [TestMethod()]
        [Owner("Mohsen")]

        public void GarageHandler_CreateGarage_Succeed()
        {
            // Arrange
            var garageCreator = new GarageCreator();
            var garageHandler = new GarageHandler();
            Garage<Vehicle> garage;

            // Act

            garage = garageHandler.CreateGarage(1);

            // Assert

            Assert.IsNotNull(garage);

        }

        [TestMethod()]
        [Owner("Mohsen")]

        public void GarageHandler_CreateGarage_Capacity_IsCorrect()
        {
            // Arrange
            var garageCreator = new GarageCreator();
            var garageHandler = new GarageHandler();
            int capacity = 1;
            Garage<Vehicle> garage;

            // Act

            garage = garageHandler.CreateGarage(1);

            // Assert

            Assert.AreEqual(garage.Capacity,capacity);

        }

    }

    
}