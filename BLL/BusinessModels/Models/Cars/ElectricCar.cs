using System;
using BLL.BusinessModels.StateMachine;
using DAL.BusinessModels.Models.Sensor;

namespace BLL.BusinessModels.Models.Sensor
{
    public class ElectricCar : ICar
    {
        private decimal _lastMeasured;
        public ICarState State { get; set; }

        public event EventHandler<CarEventArgs> DataMeasured;

        public ElectricCar()
        {
            State = new BrokenCarState();
        }

        public ElectricCar(ICarState state)
        {
            State = state;
        }

        public object GetValue()
        {
            return _lastMeasured;
        }

        public void Run()
        {
            _lastMeasured = Generate();
            DataMeasured?.Invoke(this, new CarEventArgs(_lastMeasured.ToString()));

            State.Move(this, nameof(ElectricCar));
        }

        private decimal Generate()
        {
            var rnd = new Random();
            var value = (decimal)rnd.NextDouble() * (500 - 100) + 100;

            if (value > 400)
            {
                State = new WarningCarState();
            }

            return value;
        }
    }
}
