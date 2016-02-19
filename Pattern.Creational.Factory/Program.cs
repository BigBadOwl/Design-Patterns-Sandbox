using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Factory Method creates objects without specifying the exact class to create.
 */
namespace Pattern.Creational.Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 3; i++)
            {
                var position = Factory.Get(i);
                Console.WriteLine("Where id = {0}, position = {1} ", i, position.Title);
            }
            Console.ReadKey();
        }
    }

    abstract class Position
    {
        public abstract string Title { get; }
    }

    class Manager : Position
    {
        public override string Title
        {
            get
            {
                return "Manager";
            }
        }
    }

    class Clerk : Position
    {
        public override string Title
        {
            get
            {
                return "Clerk";
            }
        }
    }

    class Programmer : Position
    {
        public override string Title
        {
            get
            {
                return "Programmer";
            }
        }
    }

    static class Factory
    {
        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static Position Get(int id)
        {
            switch (id)
            {
                case 0:
                    return new Manager();
                case 1:
                case 2:
                    return new Clerk();
                case 3:
                default:
                    return new Programmer();
            }
        }
    }
}
