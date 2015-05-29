using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ParsingText
{
    public class Story : ICollection<ISentence>
    {
        private ICollection<ISentence> sentence = new List<ISentence>();

        #region ICollection<ISentence>
        public void Add(ISentence item)
        {
            sentence.Add(item);
        }

        public void Clear()
        {
            sentence.Clear();
        }

        public bool Contains(ISentence item)
        {
            return sentence.Contains(item);
        }

        public void CopyTo(ISentence[] array, int arrayIndex)
        {
            sentence.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return sentence.Count; }
        }

        public bool IsReadOnly
        {
            get { return sentence.IsReadOnly; }
        }

        public bool Remove(ISentence item)
        {
            return sentence.Remove(item);
        }

        public IEnumerator<ISentence> GetEnumerator()
        {
            return sentence.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        //public ICollection<ISentence> SortByFlyingRange()
        //{
        //    var sortedList = sentence.OrderBy(x => x.FlyingRange).ToList();
        //    return sortedList;
        //}

    }
}
