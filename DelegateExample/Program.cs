using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    public class Car
    {
        public string Brand { get; set; }
        public int Doors { get; set; }
    }

    class Program
    {
        public delegate bool FilterDelegate(Car p);

        static void Main(string[] args)
        {
            //Create 4 Car objects
            Car c1 = new Car() { Brand = "Audi", Doors = 3 };
            Car c2 = new Car() { Brand = "Volkswagen", Doors = 4 };
            Car c3 = new Car() { Brand = "BMW", Doors = 3 };
            Car c4 = new Car() { Brand = "Volvo", Doors = 4 };

            //Create a list of Car objects and fill it
            List<Car> vehicles = new List<Car>() { c1, c2, c3, c4 };
            DisplayPeople("Coupe Models:", vehicles, IsCoupe);
            DisplayPeople("Saloon Models:", vehicles, IsSaloon);

            Console.Read();
        }

        /// <summary>
        /// A method to filter out the people you need
        /// </summary>
        /// <param name="people">A list of people</param>
        /// <param name="filter">A filter</param>
        /// <returns>A filtered list</returns>
        static void DisplayPeople(string title, List<Car> vehicles, FilterDelegate filter)
        {
            Console.WriteLine(title);

            foreach (Car c in vehicles)
            {
                if (filter(c))
                {
                    Console.WriteLine("{0}, {1} doors", c.Brand, c.Doors);
                }
            }

            Console.Write("\n\n");
        }

        //Delegate filters
        static bool IsCoupe(Car c)
        {
            return c.Doors == 3;
        }

        static bool IsSaloon(Car c)
        {
            return c.Doors == 4;
        }
        
    }
}


