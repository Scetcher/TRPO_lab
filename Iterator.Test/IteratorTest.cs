using BLL.BusinessModels.Collections;
using BLL.BusinessModels.Models.Sensor;
using BLL.Enums;
using DAL.BusinessModels.Models.Sensor;
using NUnit.Framework;

namespace Iterator.Test
{
    public class IteratorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CollectionTest_CollectionItems_True()
        {
            var collection = new CarCollection();
            var factory = new CarFactory();

            collection.AddItem(factory.CreateInstance(CarType.Smart));
            collection.AddItem(factory.CreateInstance(CarType.Smart));
            collection.AddItem(factory.CreateInstance(CarType.Diesel));
            collection.AddItem(factory.CreateInstance(CarType.Electric));
            collection.AddItem(factory.CreateInstance(CarType.Smart));

            foreach (ICar sensor in collection)
            {
                sensor.Run();
            }
        }
    }
}