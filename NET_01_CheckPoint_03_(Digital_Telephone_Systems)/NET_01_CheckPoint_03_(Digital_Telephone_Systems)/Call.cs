using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    
    public class Call : ICollection<ICallItem>
    {
        private ICollection<ICallItem> ringItem = new List<ICallItem>();

        #region ICollection<IRingItem>

        public void Add(ICallItem item)
        {
            ringItem.Add(item);
        }

        public void Clear()
        {
            ringItem.Clear();
        }

        public bool Contains(ICallItem item)
        {
            return ringItem.Contains(item);
        }

        public void CopyTo(ICallItem[] array, int arrayIndex)
        {
            ringItem.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return ringItem.Count; }
        }

        public bool IsReadOnly
        {
            get { return ringItem.IsReadOnly; }
        }

        public bool Remove(ICallItem item)
        {
            return ringItem.Remove(item);
        }

        public IEnumerator<ICallItem> GetEnumerator()
        {
            return ringItem.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
       
    }
}
