using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Airline
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
            flying = newList;//уничтожет базовый набор
        }
        public void SortByProductionDate()
        {
            this.Sort(new FlyingComparerByProductionDate());
        }
        public ICollection<IFlying> SortByFlyingRange()
        {
            var sortedList = flying.OrderBy(x => x.FlyingRange).ToList();
            return sortedList;
        }
        
        public double TotalPassengersCapacity()  //LiNQ
        {
            double sumpas = 0;
            foreach (var i in flying)
            {
                sumpas += i.PassengersCapacity;
            }
            return sumpas;
        }
        public double TotalPassengersCapacity2()
        {
            double totalCapacity2 = flying.Sum(fly => fly.PassengersCapacity);
            return totalCapacity2;
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
        public int TotalLoadingCapacity2()
        {
            int totalLoadingCapacity2 = flying.Sum(x => x.LoadingCapacity);
            return totalLoadingCapacity2;
        }
        public void FuelСonsumption(int startFuel, int endFuel)
        {
            Console.WriteLine("\nВывод самалетов по потреблению топлива от " + startFuel + " до " + endFuel+":"); // тут не должно быть
            foreach (var i in flying)
            {
                if ((i.FuelConsumption >= startFuel) && (i.FuelConsumption <= endFuel))
                    Console.WriteLine("\n" + i.Name);
            }
        }

    }
}
