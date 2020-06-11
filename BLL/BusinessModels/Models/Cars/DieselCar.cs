using System;
using BLL.BusinessModels.StateMachine;
using DAL.BusinessModels.Models.Sensor;

namespace BLL.BusinessModels.Models.Sensor
{
    public class DieselCar : ICar
    {
        private decimal _lastMeasured;

        public event EventHandler<CarEventArgs> DataMeasured;
        public ICarState State { get; set; }

        public DieselCar()
        {
            State = new BrokenCarState();
        }

        public DieselCar(ICarState state)
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

            State.Move(this, nameof(DieselCar));
        }

        private decimal Generate()
        {
            var rnd = new Random();
            var value = (decimal) rnd.NextDouble() * 1000 + 200;

            if (value > 600)
            {
                State = new WarningCarState();
            }

            return value;
        }
    }
}
