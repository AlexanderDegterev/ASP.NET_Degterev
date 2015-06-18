using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    
    public class Call : ICollection<ICallItem>
    {
        private ICollection<ICallItem> _ringItem = new List<ICallItem>();

        #region ICollection<IRingItem>

        public void Add(ICallItem item)
        {
            _ringItem.Add(item);
        }

        public void Clear()
        {
            _ringItem.Clear();
        }

        public bool Contains(ICallItem item)
        {
            return _ringItem.Contains(item);
        }

        public void CopyTo(ICallItem[] array, int arrayIndex)
        {
            _ringItem.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _ringItem.Count; }
        }

        public bool IsReadOnly
        {
            get { return _ringItem.IsReadOnly; }
        }

        public bool Remove(ICallItem item)
        {
            return _ringItem.Remove(item);
        }

        public IEnumerator<ICallItem> GetEnumerator()
        {
            return _ringItem.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
       
    }
}
