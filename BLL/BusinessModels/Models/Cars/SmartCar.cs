using System;
using BLL.BusinessModels.StateMachine;
using DAL.BusinessModels.Models.Sensor;

namespace BLL.BusinessModels.Models.Sensor
{
    public class SmartCar : ICar
    {
        private decimal _lastRPM;
        public ICarState State { get; set; }
       
        public event EventHandler<CarEventArgs> DataMeasured;

        public SmartCar()
        {
            State = new BrokenCarState();
        }

        public SmartCar(ICarState state)
        {
            State = state;
        }

        public object GetValue()
        {
            return _lastRPM;
        }

        public void Run()
        {
            _lastRPM = Generate();
            DataMeasured?.Invoke(this, new CarEventArgs(_lastRPM.ToString()));

            State.Move(this, nameof(SmartCar));
        }

        private decimal Generate()
        {
            var rnd = new Random();
            var value = (decimal)rnd.NextDouble() * 800 + 200;

            if (value > 500)
            {
                State = new WarningCarState();
            }

            return value;
        }
    }
}
