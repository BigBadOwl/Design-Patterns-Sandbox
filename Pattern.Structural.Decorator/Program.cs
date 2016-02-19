using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Decorator dynamically adds/overrides behaviour in an existing method of an object.
 */
namespace Pattern.Structural.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            ICoffee sampleCoffee = new SimpleCoffee();
            Console.WriteLine("Cost: " + sampleCoffee.getCost() + " Ingredient: " + sampleCoffee.getIngredients());

            sampleCoffee = new Milk(sampleCoffee);
            Console.WriteLine("Cost: " + sampleCoffee.getCost() + " Ingredient: " + sampleCoffee.getIngredients());

            sampleCoffee = new Sprinkles(sampleCoffee);
            Console.WriteLine("Cost: " + sampleCoffee.getCost() + " Ingredient: " + sampleCoffee.getIngredients());

            sampleCoffee = new Whip(sampleCoffee);
            Console.WriteLine("Cost: " + sampleCoffee.getCost() + " Ingredient: " + sampleCoffee.getIngredients());

            Console.ReadKey();
        }
    }

    // The interface Coffee defines the functionality of Coffee implemented by decorator
    public interface ICoffee
    {
        double getCost(); // returns the cost of the coffee
        String getIngredients(); // returns the ingredients of the coffee
    }

    // extension of a simple coffee without any extra ingredients
    public class SimpleCoffee : ICoffee
    {
        public double getCost()
        {
            return 1;
        }

        public String getIngredients()
        {
            return "Coffee";
        }
    }

    // abstract decorator class - note that it extends Coffee abstract class
    abstract public class CoffeeDecorator : ICoffee
    {
        protected readonly ICoffee decoratedCoffee;
        protected String ingredientSeparator = ", ";

        public CoffeeDecorator(ICoffee decoratedCoffee)
        {
            this.decoratedCoffee = decoratedCoffee;
        }

        public virtual double getCost()
        { // implementing methods of the abstract class
            return decoratedCoffee.getCost();
        }

        public virtual String getIngredients()
        {
            return decoratedCoffee.getIngredients();
        }
    }

    // Decorator Milk that mixes milk with coffee
    // note it extends CoffeeDecorator
    class Milk : CoffeeDecorator
    {
        double cost;
        String ingredient;

        public Milk(ICoffee decoratedCoffee)
            : base(decoratedCoffee)
        {
            cost = 0.5;
            ingredient = "Milk";
        }

        public override double getCost()
        { // overriding methods defined in the abstract superclass
            return base.getCost() + cost;
        }

        public override String getIngredients()
        {
            return base.getIngredients() + ingredientSeparator + ingredient;
        }
    }

    // Decorator Whip that mixes whip with coffee
    // note it extends CoffeeDecorator
    class Whip : CoffeeDecorator
    {
        double cost;
        String ingredient;

        public Whip(ICoffee decoratedCoffee)
            : base(decoratedCoffee)
        {
            cost = 0.7;
            ingredient = "Whip";
        }

        public override double getCost()
        {
            return base.getCost() + cost;
        }

        public override String getIngredients()
        {
            return base.getIngredients() + ingredientSeparator + ingredient;
        }
    }

    // Decorator Sprinkles that mixes sprinkles with coffee
    // note it extends CoffeeDecorator
    class Sprinkles : CoffeeDecorator
    {
        double cost;
        String ingredient;

        public Sprinkles(ICoffee decoratedCoffee)
            : base(decoratedCoffee)
        {
            cost = 0.2;
            ingredient = "Sprinkles";
        }

        public override double getCost()
        {
            return base.getCost() + cost;
        }

        public override String getIngredients()
        {
            return base.getIngredients() + ingredientSeparator + ingredient;
        }
    }
}
