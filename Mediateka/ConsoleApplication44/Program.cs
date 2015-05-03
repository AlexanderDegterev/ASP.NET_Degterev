using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication44
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediateka mediateka = new Mediateka();

            mediateka.Add(new Clip() { 
                Name = "Ace of base", 
                Duration = new TimeSpan(0, 2, 30), 
                Rating = Rating.Average, 
                CreationDate = new DateTime(2010, 10, 3) }
                );
            mediateka.Add(new Photo() { 
                Name = "Mountain", 
                Rating = Rating.Low, 
                CreationDate = new DateTime(2005, 5, 5) }
                );
            mediateka.Add(new Movie() {
                Name = "MOvie 2",
                Duration = new TimeSpan(0, 40, 0),
                Rating = Rating.High,
                CreationDate = new DateTime(2015, 05, 03)
            });

            #region add serial
            SerialBuilder serialBuilder = new SerialBuilder()
            {
                Name = "Game of Thrones",
                CreationDate = new DateTime(2009, 4, 4),
                Rating = Rating.High,
            };

            Season season = new Season() 
            { 
                Name = "dsdsd", 
                CreationDate = new DateTime(2009, 6, 6), 
                Rating = Rating.High,
                Duration = new TimeSpan(0,50,59)
            };
            season.Add(new Movie() 
            { 
                Name = "Origin",
                Duration = new TimeSpan(0, 40, 0), 
                Rating = Rating.High, 
                CreationDate = new DateTime(2009, 6, 6) 
            });

            season.Add(new Movie()
            {
                Name = "Origin 2",
                Duration = new TimeSpan(0, 40, 0),
                Rating = Rating.Average,
                CreationDate = new DateTime(2010, 08, 6)
            });

            season.Add(new Movie()
            {
                Name = "Origin 3",
                Duration = new TimeSpan(0, 40, 0),
                Rating = Rating.Average,
                CreationDate = new DateTime(2005, 01, 6)
            });

            serialBuilder.Seasons.Add(season);
            mediateka.Add(serialBuilder.Construct());
            #endregion

            mediateka.SortByCreationDate();
            Console.WriteLine("\n Сортировка по CreationDate\n");           
           

            foreach (var i in mediateka)
            {
                Console.WriteLine("{0}, {1}, {2}", i.Name, i.CreationDate, i.Rating);
            }
            
            Console.WriteLine("\n Сезон:"+season.Name+'\n');
            foreach (var i in season)
            {
                
                Console.WriteLine("{0}, {1}, {2}", i.Name, i.CreationDate, i.Rating, i.Duration);
            }
            mediateka.SortByRating();
            Console.WriteLine("\n Сортировка по Reting\n");
            foreach (var i in mediateka)
            {
                Console.WriteLine("{0}, {1}, {2}", i.Name, i.CreationDate, i.Rating);
            }
            //mediateka.SortByIntervalCreationDate();

            Console.WriteLine("\n Сортировка по <DateTime\n");
            DateTime a = new DateTime(2010, 08, 6);
            DateTime b = new DateTime(2015, 12, 31);
            Console.WriteLine("\n Вывод Mediateka с "+ a + "по "+b+"\n");
            foreach (var i in mediateka)
            {
                if ((i.CreationDate > a) && (i.CreationDate < b))
                    Console.WriteLine("{0}, {1}, {2}", i.Name, i.CreationDate, i.Rating);
            }


            

            //object obj = new object();
            //obj = new object();
            //object obj1 = new object();

            //string sss = "System.Object";
            //Console.WriteLine("{0} {1}", obj.GetHashCode(), obj1.GetHashCode());

            //Dictionary<Movie, string> dic = new Dictionary<Movie, string>();
            
        }
    }
}
