using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BLL.BusinessModels.Models.Sensor;
using BLL.Enums;
using NUnit.Framework;

namespace Factory.Test
{
    public class CarFactoryTest
    {
        private CarFactory _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new CarFactory();
        }

        [Test]
        public void SensorFactory_CreatedSensor_True()
        {
            ICollection<ICar> cars = new List<ICar>
            {
                _factory.CreateInstance(CarType.Electric),
                _factory.CreateInstance(CarType.Diesel),
                _factory.CreateInstance(CarType.Electric)
            };

            foreach (var car in cars)
            {
                car.Run();
            }

            Assert.AreEqual(typeof(ElectricCar), cars.ElementAt(0).GetType());
        }
    }
}