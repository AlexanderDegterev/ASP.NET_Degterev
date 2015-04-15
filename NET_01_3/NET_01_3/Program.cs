using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_3
{
    class Triangle
    {

        public static void Main()
        {

            Console.WriteLine("Введите стороны и углы треугольника:");
            inputTriangle();    
            double pp = (arr[0] + arr[1] + arr[2]) / 2;
            Console.Clear();            
                    Console.WriteLine("Полное описание треугольника:");
                    Console.WriteLine("Периметр : {0}см", arr[0] + arr[1] + arr[2]);
                    Console.WriteLine("Площадь : {0}см", Math.Sqrt(pp * (pp - arr[0]) * (pp - arr[1]) * (pp - arr[2])));                   
                    type();                 

            Console.ReadLine();
        }
        public static void type()// проверить на углы
            //Перечислитель !!!
            /*{
            List<int> arr = new List<int>();
            Random ran = new Random();

            for (int i = 0; i < 10; i++)
                arr.Add(ran.Next(1, 20));

            // Используем перечислитель
            IEnumerator<int> etr = arr.GetEnumerator();
            while (etr.MoveNext())
                Console.Write(etr.Current + "\t");

            Console.WriteLine("\nПовторный вызов перечислителя: \n");
            // Сбросим значение и вновь исользуем перечислитель
            // для доступа к коллекции
            etr.Reset();
            while (etr.MoveNext())
                Console.Write(etr.Current + "\t");

            Console.ReadLine();
        }*/ 


        {
            int[] a = new int[6];
            for (int i = 0; i < 6; i++)
            {
                a[i] = Convert.ToInt32(arr[i]);
            }
            if (a[0] == a[1] && a[1] == a[2])
            {
                Console.WriteLine("Треугольник равносторонний");
                return;
            }
            if (a[0] == a[1] || a[1] == a[2] || a[2] == a[0])
            {
                Console.WriteLine("Треугольник равноберенный");
            }
            if (a[0] != a[1] && a[1] != a[2])
            {
                Console.WriteLine("Треугольник разносторонний");
            }
        }
        public int Perimetr()
        {
            return arr[0] + arr[1] + arr[2];
        }

        public static double[] arr = new double[6];
        public static void inputTriangle()
        {
        beg_input:
            for (int i = 0; i < 6; i++)
            {
                if (i < 3)
                {
                    Console.WriteLine("Введите сторону №" + (i+1));
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Введите угол  №" + (i-2)+" Помни, что сумма углов в треугольнике равна 180!");
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            if (arr[3] + arr[4] + arr[5] != 180)
            {
                Console.Clear();
                Console.WriteLine("Сумма углов не равна 180. Повторите ввод");
                goto beg_input;
            }
            Console.Clear();
        }
    }
}