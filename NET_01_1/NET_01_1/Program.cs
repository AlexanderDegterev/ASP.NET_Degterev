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
        private int a;
        public int A
    {            
        get { return a; }
        set { a = value; }
    }
        private int b;
        public int B
    {
        get { return b; }
        set { b = value; }
    }
        private int x;
        public int X
    {
        get { return x; }
        set { x = value; }
    }
        
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
                LF.A = 2;
                LF.B = 3;
                LF.X = perem;
                LF.Func();


            }
        }
        
    }
}

