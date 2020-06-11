using System;
using BLL.BusinessModels.Models.Sensor;
using DAL.BusinessModels.Models.Sensor;

namespace BLL.BusinessModels.StateMachine
{
    public class WarningCarState : ICarState
    {
        public void Move(ICar car, string name)
        {
            Console.WriteLine($"{name} has an error");
        }
    }
}