using System;
using BLL.BusinessModels.Collections;
using BLL.BusinessModels.Models.Sensor;
using BLL.BusinessModels.StateMachine;
using NUnit.Framework;

namespace State.Test
{
    public class StateTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GenericTest()
        {
            var collection = new CarCollection();

            collection.AddItem(new ElectricCar(new ActiveCarState()));
            collection.AddItem(new DieselCar(new WarningCarState()));
            collection.AddItem(new SmartCar(new BrokenCarState()));

            for (var i = 0; i < 5; i++)
            {
                foreach (ICar sensor in collection)
                {
                    sensor.Run();
                }
                Console.WriteLine("_______________________________________");
            }
        }
    }
}