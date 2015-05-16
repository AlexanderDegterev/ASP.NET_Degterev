using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    public class AirPort : ICollection<IFlying>
    {
        private ICollection<IFlying> flying = new List<IFlying>();
        #region ICollection<IFlying>


        public void Add(IFlying item)
        {
            flying.Add(item);
        }

        public void Clear()
        {
            flying.Clear();
        }

        public bool Contains(IFlying item)
        {
            return flying.Contains(item);
        }

        public void CopyTo(IFlying[] array, int arrayIndex)
        {
            flying.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return flying.Count; }
        }

        public bool IsReadOnly
        {
            get { return flying.IsReadOnly; }
        }

        public bool Remove(IFlying item)
        {
            return flying.Remove(item);
        }

        public IEnumerator<IFlying> GetEnumerator()
        {
            return flying.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        protected void Sort(IComparer<IFlying> comparer)
        {
            var newList = flying.ToList();
            newList.Sort(comparer);
            flying = newList;
        }
        public void SortByProductionDate()
        {
            this.Sort(new FlyingComparerByProductionDate());
        }
        public void SortByFlyingRange()
        {
            this.Sort(new FlyingComparerByFlyingRange());
        }
        

        /* public override string ToString()
        {
            return String.Format("Марка: {0}\tМодель: {1}\tЦена: {2}\tМощьность:{3}\t  ",
                this.Brand,this.Model,this.Price,this.Power);
        }*/

        internal void PrintInfoToConsole()
        {
            foreach (var i in flying)
            {
                Console.WriteLine(i.getInfo());
            }
        }
        public double TotalPassengersCapacity()
        {
            double sumpas = 0;
            foreach (var i in flying)
            {
                sumpas += i.PassengersCapacity;
            }
            return sumpas;
        }
        public int TotalLoadingCapacity()
        {
            int sumLP = 0;
            foreach (var i in flying)
            {
                sumLP += i.LoadingCapacity;
            }
            return sumLP;
        }


    }
}
