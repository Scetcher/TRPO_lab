using System;

namespace DAL.BusinessModels.Models.Sensor
{
    public class CarEventArgs : EventArgs
    {
        public string Data { get; }

        public CarEventArgs(string data)
        {
            Data = data;
        }
    }
}