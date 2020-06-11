using System;
using BLL.BusinessModels.Models.Sensor;
using DAL.BusinessModels.Models.Sensor;

namespace BLL.BusinessModels.StateMachine
{
    public class ActiveCarState : ICarState
    {
        public void Move(ICar car, string name)
        {
            Console.WriteLine($"{name} active and run with: {car.GetValue()} RPM");
        }
    }
}