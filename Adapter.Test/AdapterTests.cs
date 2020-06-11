using BLL.BusinessModels.AdapterTarget;
using BLL.BusinessModels.Models.Sensor;
using BLL.BusinessModels.Models.SensorToServerAdapter;
using BLL.Enums;
using NUnit.Framework;

namespace Adapter.Test
{
    public class AdapterTests
    {
        private BigTruckWithSmallWheels target;

        [SetUp]
        public void Setup()
        {
            target = new BigTruckWithSmallWheels();
        }

        [Test]
        public void Adapter_TestAdapter_True()
        {
            var factory = new CarFactory();

            target.AddProvider(new CarAdapter(factory.CreateInstance(CarType.Electric)));
            target.AddProvider(new CarAdapter(factory.CreateInstance(CarType.Diesel)));

            target.SendMeasurements();
            Assert.True(true);
        }
    }
}