using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    public class AirPort : ICollection<IAirline>
    {
        private ICollection<IAirline> airline = new List<IAirline>();
        #region ICollection<IAirLine>


        public void Add(IAirline item)
        {
            airline.Add(item);
        }

        public void Clear()
        {
            airline.Clear();
        }

        public bool Contains(IAirline item)
        {
            return airline.Contains(item);
        }

        public void CopyTo(IAirline[] array, int arrayIndex)
        {
            airline.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return airline.Count; }
        }

        public bool IsReadOnly
        {
            get { return airline.IsReadOnly; }
        }

        public bool Remove(IAirline item)
        {
            return airline.Remove(item);
        }

        public IEnumerator<IAirline> GetEnumerator()
        {
            return airline.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        protected void Sort(IComparer<IAirline> comparer)
        {
            var newList = airline.ToList();
            newList.Sort(comparer);
            airline = newList;
        }
        public void SortByProductionDate()
        {
            this.Sort(new AirlineComparerByProductionDate());
        }

        /* public override string ToString()
        {
            return String.Format("Марка: {0}\tМодель: {1}\tЦена: {2}\tМощьность:{3}\t  ",
                this.Brand,this.Model,this.Price,this.Power);
        }*/
    }
}
