using System;
using BLL.BusinessModels.StateMachine;
using DAL.BusinessModels.Models.Sensor;

namespace BLL.BusinessModels.Models.Sensor
{
    public interface ICar
    {
        public ICarState State { get; set; }

        public object GetValue();

        event EventHandler<CarEventArgs> DataMeasured;

        void Run();
    }
}