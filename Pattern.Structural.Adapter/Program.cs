using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Adapter allows classes with incompatible interfaces to work together by wrapping its own interface around that of an already existing class.
 */
namespace Pattern.Structural.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IEmployee> list = new List<IEmployee>();
            list.Add(new Employee("Tom"));
            list.Add(new Employee("Jerry"));
            list.Add(new ConsultantToEmployeeAdapter("Bruno"));  //consultant from existing class
            ShowHappiness(list);

            Console.ReadKey();
        }

        //*** Code below from the existing library does not need to be changed ***
        static void ShowHappiness(List<IEmployee> list)
        {
            foreach (IEmployee i in list)
                i.ShowHappiness();
        }
    }

    //from the existing library, does not need to be changed
    public interface IEmployee
    {
        void ShowHappiness();
    }

    public class Employee : IEmployee
    {
        private string name;

        public Employee(string name)
        {
            this.name = name;
        }

        void IEmployee.ShowHappiness()
        {
            System.Console.WriteLine("Employee " + this.name + " is happy");
        }
    }

    //existing class does not need to be changed
    public class Consultant
    {
        private string name;

        public Consultant(string name)
        {
            this.name = name;
        }

        protected void ShowSmile()
        {
            System.Console.WriteLine("Consultant " + this.name + " smiles");
        }
    }

    public class ConsultantToEmployeeAdapter : Consultant, IEmployee
    {
        public ConsultantToEmployeeAdapter(string name)
            : base(name)
        {
        }

        void IEmployee.ShowHappiness()
        {
            base.ShowSmile();  //call the parent Consultant class
        }
    }
}
