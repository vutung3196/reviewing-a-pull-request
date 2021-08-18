using System;

namespace DesignPatterns
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Please select one option");
            Console.WriteLine("1. Abstract factory");
            Console.WriteLine("2. Adapter");
            Console.WriteLine("3. Builder");
            Console.WriteLine("4. Decorator");
            Console.WriteLine("5. Iterator");
            Console.WriteLine("6. Observer");
            Console.WriteLine("7. Singleton");
            Console.WriteLine("8. Strategy");
            var selection = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(selection))
            {
                switch (int.Parse(selection))
                {
                    case 1:
                    {
                        AbstractFactoryMain.Run();
                        break;
                    }
                    case 2:
                    {
                        AdapterProgram.Run();
                        break;
                    }
                    case 3:
                    {
                        BuilderProgram.Run();
                        break;
                    }
                    case 4:
                    {
                        DecoratorProgram.Run();
                        break;
                    }
                    case 5:
                    {
                        IteratorProgram.Run();
                        break;
                    }
                    case 6:
                    {
                        ObserverProgram.Run();
                        break;
                    }
                    case 7:
                    {
                        SingletonProgram.Run();
                        break;
                    }
                    case 8:
                    {
                        StrategyProgram.Run();
                        break;
                    }
                }
            }
        }
    }
}