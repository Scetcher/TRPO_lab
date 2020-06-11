using System;
using System.Collections.Generic;

namespace BLL.BusinessModels.AdapterTarget
{
    public class BigTruckWithSmallWheels
    {
        private ICollection<IDataProvider> providers;

        public BigTruckWithSmallWheels()
        {
            providers = new List<IDataProvider>();
        }

        public void AddProvider(IDataProvider newProvider)
        {
            providers.Add(newProvider);
        }

        public void SendMeasurements()
        {
            foreach (var dataProvider in providers)
            {
                Console.WriteLine($"Data sent to server: {dataProvider.RunCar()}");
            }
        }
    }
}
