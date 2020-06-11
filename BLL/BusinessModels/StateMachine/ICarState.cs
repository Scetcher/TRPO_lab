using BLL.BusinessModels.Models.Sensor;
using DAL.BusinessModels.Models.Sensor;

namespace BLL.BusinessModels.StateMachine
{
    public interface ICarState
    {
        void Move(ICar car, string name);
    }
}