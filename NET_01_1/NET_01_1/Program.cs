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
        private void Func()
        {
            int y = a * x + b;
            Console.WriteLine("результат выполнения функции: " + y);
        }

        class Program
        {
            public static void Main()
            {
                Console.Write("Введите целочисленное значение х: ");
                int perem = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Х равен:" + perem);

                LinearFunction LF = new LinearFunction();
                LF.x = perem;
                LF.Func();


            }
        }
        
    }
}

