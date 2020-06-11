using System.Threading;
using BLL.BusinessModels.AdapterTarget;
using BLL.BusinessModels.Models.Sensor;
using DAL.BusinessModels.Models.Sensor;

namespace BLL.BusinessModels.Models.SensorToServerAdapter
{
    public class CarAdapter : IDataProvider
    {
        private ICar _car;
        private AutoResetEvent resetEvent;

        private string _data = "";

        public CarAdapter(ICar car)
        {
            resetEvent = new AutoResetEvent(false);

            _car = car;
            _car.DataMeasured += CarOnDataMeasured;

        }

        private void CarOnDataMeasured(object? sender, CarEventArgs e)
        {
            _data = e.Data;
            resetEvent.Set();
        }

        public string RunCar()
        {
            _car.Run();
            resetEvent.WaitOne();

            return _data;
        }
    }
}
