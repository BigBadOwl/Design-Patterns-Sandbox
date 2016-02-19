using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Strategy allows one of a family of algorithms to be selected on-the-fly at runtime.
 */
namespace Pattern.Behavioral.Strategy
{
    /** Tests the pattern */
    class StrategyExample
    {
        static void Main(String[] args)
        {
            Context context;

            // Three contexts following different strategies
            context = new Context(new Add());
            int resultA = context.executeStrategy(3, 4);

            context = new Context(new Subtract());
            int resultB = context.executeStrategy(3, 4);

            context = new Context(new Multiply());
            int resultC = context.executeStrategy(3, 4);

            System.Console.WriteLine("Result A : " + resultA);
            System.Console.WriteLine("Result B : " + resultB);
            System.Console.WriteLine("Result C : " + resultC);

            System.Console.ReadLine();
        }

        /** The classes that implement a concrete strategy should implement this.
        * The Context class uses this to call the concrete strategy. */
        interface IStrategy
        {
            int execute(int a, int b);
        }

        /** Implements the algorithm using the strategy interface */
        class Add : IStrategy
        {
            public int execute(int a, int b)
            {
                System.Console.WriteLine("Called Add's execute()");
                return a + b;  // Do an addition with a and b
            }
        }

        class Subtract : IStrategy
        {
            public int execute(int a, int b)
            {
                System.Console.WriteLine("Called Subtract's execute()");
                return a - b;  // Do a subtraction with a and b
            }
        }

        class Multiply : IStrategy
        {
            public int execute(int a, int b)
            {
                System.Console.WriteLine("Called Multiply's execute()");
                return a * b;   // Do a multiplication with a and b
            }
        }

        // Configured with a ConcreteStrategy object and maintains
        // a reference to a Strategy object 
        class Context
        {
            private IStrategy strategy;

            public Context(IStrategy strategy)
            {
                this.strategy = strategy;
            }

            public int executeStrategy(int a, int b)
            {
                return this.strategy.execute(a, b);
            }
        };
    }
}
