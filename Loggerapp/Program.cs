using System;

class LoggerSingleton
{
    public enum Level { Comment, Warning, Error }
    static LoggerSingleton? instance;
    protected LoggerSingleton() { }
    public static LoggerSingleton Instance()
    {
        if (instance == null)
        {
            instance = new LoggerSingleton();
        }
        return instance;
    }
    public void Log(Level level, string message)
    {
        switch (level)
        {
            case Level.Comment:
                Console.WriteLine($"Comment: {message}");
                break;
            case Level.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {message}");
                Console.ResetColor();
                break;
            case Level.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {message}");
                Console.ResetColor();
                Environment.Exit(1);
                break;
        }
    }
}

class LoggerStatic
{
    public enum Level { Comment, Warning, Error }
    static LoggerStatic() { }
    public static void Log(Level level, string message)
    {
        switch (level)
        {
            case Level.Comment:
                Console.WriteLine($"Comment: {message}");
                break;
            case Level.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {message}");
                Console.ResetColor();
                break;
            case Level.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {message}");
                Console.ResetColor();
                Environment.Exit(1);
                break;
        }
    }
}

// Animal Interface
interface IAnimal
{
    void Speak();
}

// Dog implementation
class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("woof");
    }
}

// Cat implementation
class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("meow");
    }
}

// Simple Factory implementation
class AnimalFactory
{
    public enum AnimalType
    {
        Dog,
        Cat
    }

    public static IAnimal CreateAnimal(AnimalType type)
    {
        switch (type)
        {
            case AnimalType.Dog:
                return new Dog();
            case AnimalType.Cat:
                return new Cat();
            default:
                throw new ArgumentException($"Animal type {type} is not supported.");
        }
    }
}

class Program
{
    static void Main()
    {
        LoggerSingleton loggerSingleton = LoggerSingleton.Instance();
        loggerSingleton.Log(LoggerSingleton.Level.Comment, "Singleton Comment");
        LoggerStatic.Log(LoggerStatic.Level.Comment, "Static Comment");
        loggerSingleton.Log(LoggerSingleton.Level.Warning, "Singleton Warning");
        LoggerStatic.Log(LoggerStatic.Level.Warning, "Static Warning");

        // Animal Factory tests - added code
        Console.WriteLine("\n===== Animal Factory =====");
        IAnimal dog = AnimalFactory.CreateAnimal(AnimalFactory.AnimalType.Dog);
        IAnimal cat = AnimalFactory.CreateAnimal(AnimalFactory.AnimalType.Cat);

        Console.Write("Dog says: ");
        dog.Speak();

        Console.Write("Cat says: ");
        cat.Speak();

        // Comment out error logging to allow animal tests to run
        // Uncomment one of these to test error logging 
        //loggerSingleton.Log(LoggerSingleton.Level.Error, "Singleton Error");
        //LoggerStatic.Log(LoggerStatic.Level.Error, "Static Error");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}