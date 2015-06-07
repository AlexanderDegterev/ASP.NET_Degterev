using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    
    public class Ring : ICollection<IRingItem>
    {
        private ICollection<IRingItem> ringItem = new List<IRingItem>();

        #region ICollection<IRingItem>

        public void Add(IRingItem item)
        {
            ringItem.Add(item);
        }

        public void Clear()
        {
            ringItem.Clear();
        }

        public bool Contains(IRingItem item)
        {
            return ringItem.Contains(item);
        }

        public void CopyTo(IRingItem[] array, int arrayIndex)
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

        public bool Remove(IRingItem item)
        {
            return ringItem.Remove(item);
        }

        public IEnumerator<IRingItem> GetEnumerator()
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
