namespace Packt.Shared;
public partial class Person : object
{
    public string? Name { get; set; }
    public DateTimeOffset Born { get; set; }
    //This has been moved to PersonAutoGen.cs as a property
    //public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public List<Person> Children = new();
    //Dont use consts, read only is better.Consts are set at compile time
    public const string Species = "Homo Sapiens";
    //Good Practice, values are loaded at runtime, fields can be set using a constructor or field assignment.
    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;

    public Person()
    {
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }

    public string OptionParameters(int count, string command="Run!", double number = 0.0, bool active = true)
    {
        string opt = $"command is {command}, number is {number}, active is {active}";
        return opt;
    }

    public void PassingParameters(int w, in int x, ref int y, out int z)
    {
        // out parameters cannot have a default and they
        // must be initialized inside the method.
        z = 100;
        // Increment each parameter except the read-only x.
        w++;
        // x++; // Gives a compiler error!
        y++; 
        z++;
        WriteLine($"In the method: w={w}, x={x}, y={y}, z={z}");
    }

    //Method that returns a tuple: (string, int).
    public (string, int) GetFruit()
    {
        return ("Apples", 5);
    }

    public (string Name, int Number) GetNamedFruit() 
    {
        return (Name: "Apples", Number: 5);
    }

    // Deconstructors: Break down this object into parts.
    public void Deconstruct(out string? name, out DateTimeOffset dob)
    {
        name = Name;
        dob = Born;
    }
    public void Deconstruct(out string? name, out DateTimeOffset dob, out WondersOfTheAncientWorld fav)
    {
        name = Name;
        dob = Born;
        fav = FavoriteAncientWonder;
    }

    // Method with a local function.
    public static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
        }
        return localFactorial(number);
        int localFactorial(int localNumber) // Local function.
        {
            if (localNumber == 0)
            {
                return 1;
            }
            return localNumber * localFactorial(localNumber - 1);
        }
    }

}
