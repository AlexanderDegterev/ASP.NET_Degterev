using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint_Symbol
{
    public class Textual : ICollection<ISymbol>
    {
        private ICollection<ISymbol> symbols = new List<ISymbol>();

        #region ICollection<ISymbol>
        public void Add(ISymbol item)
        {
            symbols.Add(item);
        }

        public void Clear()
        {
            symbols.Clear();
        }

        public bool Contains(ISymbol item)
        {
            return symbols.Contains(item);
        }

        public void CopyTo(ISymbol[] array, int arrayIndex)
        {
            symbols.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return symbols.Count; }
        }

        public bool IsReadOnly
        {
            get { return symbols.IsReadOnly; }
        }

        public bool Remove(ISymbol item)
        {
            return symbols.Remove(item);
        }

        public IEnumerator<ISymbol> GetEnumerator()
        {
            return symbols.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
