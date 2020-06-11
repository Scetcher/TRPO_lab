using System.Collections;

namespace BLL.BusinessModels.Collections
{
    public abstract class IteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
}
