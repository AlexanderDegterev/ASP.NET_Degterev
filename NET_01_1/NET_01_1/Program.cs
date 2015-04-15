using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_1
{
    class LinearFunction
    {
        //закрытые элементы
        private int a = 2, b = 3;
        public int x;
        private void func()
        {
            int y = a * x + b;
            Console.WriteLine("результат выполнения функции: " + y);
        }

        //rrr
        class Program
        {
            public static void Main()
            {
                Console.Write("Введите целочисленное значение х: ");
                int perem = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Х равен:" + perem);

                LinearFunction ob = new LinearFunction();
                ob.x = perem;
                ob.func();


            }
        }
        //  private static int func(int x1, int x2)
        // {
        //   if ((x1 == 0) & (x2 == 0))
        // {
        //   return 0;
    }
}

