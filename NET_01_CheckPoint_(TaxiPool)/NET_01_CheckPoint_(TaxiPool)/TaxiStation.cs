using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__TaxiStation_
{
    public class TaxiStation : ICollection<ICars>
    {
        private ICollection<ICars>  car = new List<ICars>();

        public void Add(ICars item)
        {
            car.Add(item);
        }

        public void Clear()
        {
            car.Clear();
        }

        public bool Contains(ICars item)
        {
            return car.Contains(item);
        }

        public void CopyTo(ICars[] array, int arrayIndex)
        {
           car.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return car.Count; }
        }

        public bool IsReadOnly
        {
            get { return car.IsReadOnly; }
        }

        public bool Remove(ICars item)
        {
            return car.Remove(item);
        }

        public IEnumerator<ICars> GetEnumerator()
        {
            return car.GetEnumerator();
        }
        private void Sort(IComparer<ICars> comparer)
        {
            var newList = car.ToList();
            newList.Sort(comparer);
            car = newList;
        }
        public void SortByFuelUsage()
        {
            this.Sort( new CarsComparerBYFuelUsage() );
        }
        internal void PrintInfoToConsole()
        {
            foreach (var i in car)
            {
                Console.WriteLine(i.getInfo());
            }
        }
        public int TotalCost()
        {
            int totalcost = 0;
            foreach (var i in car)
            {
                totalcost += i.Price;
            }
            return totalcost;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal void RangeSpeed(int minSpeed, int maxSpeed)
        {
            Console.WriteLine("\nТранспортные средства с макс.скоростью от " + minSpeed + " до " + maxSpeed + ":");
            foreach (var i in car)
            {
                if ((i.Speed >= minSpeed) && (i.Speed <= maxSpeed))
                    Console.WriteLine(i.Brand +" "+ i.Model);
            }
        }
    }
}
 