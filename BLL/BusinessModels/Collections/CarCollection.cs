using System.Collections;
using System.Collections.Generic;
using BLL.BusinessModels.Models.Sensor;
using DAL.BusinessModels.Models.Sensor;

namespace BLL.BusinessModels.Collections
{
    public class CarCollection : IteratorAggregate
    {
        List<ICar> _collection = new List<ICar>();

        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<ICar> getItems()
        {
            return _collection;
        }

        public void AddItem(ICar item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new CarIterator(this, _direction);
        }
    }
}
