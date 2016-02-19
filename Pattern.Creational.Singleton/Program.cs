using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Singleton restricts object creation for a class to only one instance.
 */
namespace Pattern.Creational.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance;
            s1.SetNum(1);

            Singleton s2 = Singleton.Instance;//returns the same as s1
            Console.WriteLine("s1 = {0}", s1.GetNum());
            Console.WriteLine("s2 = {0}", s2.GetNum());

            s1.SetNum(5);
            Console.WriteLine("s1 = {0}", s1.GetNum());
            Console.WriteLine("s2 = {0}", s2.GetNum());
            Console.ReadKey();
        }
    }

    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        private int _i = 0;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public void SetNum(int v)
        {
            _i = v;
        }

        public int GetNum()
        {
           return(_i);
        }
    }
}
