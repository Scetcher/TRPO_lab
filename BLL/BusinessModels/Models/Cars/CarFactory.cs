using System;
using BLL.Enums;
using DAL.BusinessModels.Models.Sensor;

namespace BLL.BusinessModels.Models.Sensor
{
    public class CarFactory
    {
        public CarFactory()
        {

        }

        public ICar CreateInstance(CarType type)
        {
            return type switch
            {
                CarType.Smart    => new SmartCar(),
                CarType.Diesel   => new DieselCar(),
                CarType.Electric => new ElectricCar(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
