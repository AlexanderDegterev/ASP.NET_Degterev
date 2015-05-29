using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingText
{
    class Lexicon : ICollection<IWord>
    {
        private ICollection<IWord> word = new List<IWord>();

        public void Add(IWord item)
        {
            word.Add(item);
        }

        public void Clear()
        {
            word.Clear();
        }

        public bool Contains(IWord item)
        {
            return word.Contains(item);
        }

        public void CopyTo(IWord[] array, int arrayIndex)
        {
            word.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return word.Count; }
        }

        public bool IsReadOnly
        {
            get { return word.IsReadOnly; }
        }

        public bool Remove(IWord item)
        {
            return word.Remove(item);
        }

        public IEnumerator<IWord> GetEnumerator()
        {
            return word.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
