using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Command creates objects which encapsulate actions and parameters.
 */
namespace Pattern.Behavioural.Command
{
    /* The test class or client */
    internal class Program
    {
        public static void Main(string[] args)
        {
            Light lamp = new Light();
            ICommand switchUp = new FlipUpCommand(lamp);
            ICommand switchDown = new FlipDownCommand(lamp);

            Switch s = new Switch();
            string arg = args.Length > 0 ? args[0].ToUpper() : null;
            if (arg == "ON")
            {
                s.StoreAndExecute(switchUp);
            }
            else if (arg == "OFF")
            {
                s.StoreAndExecute(switchDown);
            }
            else
            {
                Console.WriteLine("Argument \"ON\" or \"OFF\" is required.");
            }
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    /* The Invoker class */
    public class Switch
    {
        private List<ICommand> _commands = new List<ICommand>();

        public void StoreAndExecute(ICommand command)
        {
            _commands.Add(command);
            command.Execute();
        }
    }

    /* The Receiver class */
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("The light is on");
        }

        public void TurnOff()
        {
            Console.WriteLine("The light is off");
        }
    }

    /* The Command for turning on the light - ConcreteCommand #1 */
    public class FlipUpCommand : ICommand
    {
        private Light _light;

        public FlipUpCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }
    }

    /* The Command for turning off the light - ConcreteCommand #2 */
    public class FlipDownCommand : ICommand
    {
        private Light _light;

        public FlipDownCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }
    }
}
