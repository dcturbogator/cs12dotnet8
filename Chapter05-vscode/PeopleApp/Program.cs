using System;
using System.Data;
using Packt.Shared;
using Fruit = (string Name, int Number); // Aliasing a tuple type.
ConfigureConsole();
//ConfigureConsole(useComputerCulture: true);
//ConfigureConsole(culture: "fr-FR");

Person bob = new();
bob.Name = "Bob Smith";
bob.Born = new DateTimeOffset(year: 1965, month: 12, day: 22, hour: 16, minute: 28, second: 0, offset: TimeSpan.FromHours(-5));
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
//You can use with | operator to store multiple enums, you could also use 18 (16+2 as bit, check the class for description)
bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
//bob.BucketList = (WondersOfTheAncientWorld)18;

//Give bob some children
Person alfred = new Person();
alfred.Name = "Alfred";
bob.Children.Add(alfred); //Works with all versions of C#;
bob.Children.Add(new Person { Name = "Bella" }); // Works with C# 3 and later.
bob.Children.Add(new () { Name = "Zoe" }); // Works with C# 9 and later

WriteLine($"{bob.Name} was born on {bob.Born:D}.");
WriteLine($"{bob.Name}'s favorite wonder is {bob.FavoriteAncientWonder}. Its integer is {(int)bob.FavoriteAncientWonder}");
WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}.");
WriteLine($"{bob.Name} has {bob.Children.Count} children: ");
for (int i = 0; i < bob.Children.Count; i++)
{
    WriteLine($"{bob.Children[i].Name}");
}

Person alice = new()
{
    Name = "Alice Jones",
    Born = new(1998, 3, 7, 16, 28, 0, TimeSpan.Zero)
};
WriteLine($"{alice.Name} was born on {alice.Born:D}.");

WriteLine("------------Bank Account-----------------");
/*making interest rate a static field it can be shared across instances
as you can see below by setting it only once*/
BankAccount.InterestRate = 0.012M;
BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;
WriteLine($"{jonesAccount.AccountName} earned {jonesAccount.Balance * BankAccount.InterestRate:C} interest.");

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine($"{gerrierAccount.AccountName} earned {gerrierAccount.Balance * BankAccount.InterestRate:C} interest.");

WriteLine("------------Making a field constant-----------------");
/*to get the value of a constant field you have to write the name of the class 'Person.Species'
Constant are not the best practice because values must be known at compile time and must be 
expressible as a literal string, Boolean, or number value.*/
WriteLine($"{bob.Name} is a {Person.Species}.");
/*using readonly is better*/
WriteLine($"{bob.Name} was born on {bob.HomePlanet}.");


WriteLine("------------Requiring fields to be set during instantiation-----------------");
// Book book = new()
// {
//     Isbn = "23423423",
//     Title = "C# 12 and .NET 8"
// };
Book book = new(isbn: "978-1803237800",
  title: "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals")
{
  Author = "Kristof B Anders",
  PageCount = 821
};
WriteLine($"{book.Isbn}: {book.Title} written by {book.Author} has {book.PageCount:N0} pages.");

WriteLine("------------Initializing fields with constructors-----------------");
Person blankPerson = new();
WriteLine($"{blankPerson.Name} of {blankPerson.HomePlanet} was created at {blankPerson.Instantiated:hh:mm:ss} on a {blankPerson.Instantiated:dddd}.");

WriteLine("------------Defining Multiple constructors-----------------");
Person gunny = new Person(initialName: "Gunny", homePlanet: "Mars");
WriteLine($"{gunny.Name} of {gunny.HomePlanet} was created at {gunny.Instantiated:hh:mm:ss} on a {gunny.Instantiated:dddd}.");

WriteLine("------------Passing optional parameters-----------------");
WriteLine(bob.OptionParameters(3));
WriteLine(bob.OptionParameters(3,"Jump!", 98.5));

WriteLine("------------Naming parameter values when calling methods-----------------");
WriteLine(bob.OptionParameters(3, number: 52.7, command: "Hide!"));

WriteLine("------------Controlling how parameters are passed-----------------");
//By value, out parameter, ref parameter, in parameter
// int a = 10; 
// int b = 20; 
// int c = 30;
// int d = 40;
int e = 50;
int f = 60;
int g = 70;
// WriteLine($"Before: a={a}, b={b}, c={c}, d={d}"); 
// bob.PassingParameters(a, b, ref c, out d);
// WriteLine($"After: a={a}, b={b}, c={c}, d={d}");

WriteLine($"Before: e={e}, f={f}, g={g}, h doesn't exist yet!");
// Simplified C# 7 or later syntax for the out parameter.
bob.PassingParameters(e, f, ref g, out int h);
WriteLine($"After: e={e}, f={f}, g={g}, h={h}");

WriteLine("------------Combining multiple returned values using tuples-----------------");
(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

WriteLine("------------Naming the fields of a tuple-----------------");
var fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");
var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
var thing2 = (bob.Name, bob.Children.Count); 
WriteLine($"{thing2.Name} has {thing2.Count} children.");

WriteLine("------------Aliasing tuples-----------------");
Fruit namedFruit = bob.GetNamedFruit();
WriteLine($"There are {namedFruit.Number} {namedFruit.Name}.");

WriteLine("------------Deconstructing tuples-----------------");
(string fruitName, int fruitNumber) = bob.GetNamedFruit();
//a deconstructed tupe returns two separate variables instead of namedFruit.Number it is fruitNumber
WriteLine($"Deconstructed tuple: {fruitName}, {fruitNumber}");

WriteLine("------------Deconstructing other types using tuples-----------------");
var (name1, dob1) = bob; // Implicitly calls the Deconstruct method in Person.cs.
WriteLine($"Deconstructed person: {name1}, {dob1}");
var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed person: {name2}, {dob2}, {fav2}");

WriteLine("------------Implementing functionality using local functions-----------------");
// Change to -1 to make the exception handling code execute
int number = 5;
try
{
  WriteLine($"{number}! is {Person.Factorial(number)}");
}
catch (System.Exception ex)
{
  WriteLine($"{ex.GetType()} says: {ex.Message} number was {number}.");
}

WriteLine("------------Splitting classes using partial-----------------");
WriteLine("Nothing to show here, we added a new class called PersonAutoGen.cs as a partial class by using the partial keyword on Person.cs and PersonAutoGen.cs");

WriteLine("------------Controlling access with properties and indexers-----------------");
WriteLine("---Defining read-only properties---");
Person sam = new()
{
  Name = "Sam",
  Born = new(1969, 6, 25, 0, 0, 0, TimeSpan.Zero)
};
WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);
WriteLine("---Defining settable Properties---");
sam.FavoriteIceCream = "Chocolate Chip Cookie Dough";
WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}");
//string color = "Red";
string color = "Black";
try
{
  sam.FavoritePrimaryColor = color;
  WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");
}
catch (Exception ex)
{
  WriteLine($"Tried to set {sam.FavoritePrimaryColor} to '{color}':{ex.Message}");
}
WriteLine("------------Limiting flags enum values-----------------");
//Throws an error
//bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia | WondersOfTheAncientWorld.GreatPyramidOfGiza;
//Throws an error
//bob.FavoriteAncientWonder = (WondersOfTheAncientWorld)128;
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.GreatPyramidOfGiza;
WriteLine($"Bob's favorite Ancient wonder is {bob.FavoriteAncientWonder}");
WriteLine("------------Defining indexers-----------------");
sam.Children.Add(new() { Name = "Charlie", Born = new(2010, 3, 18, 0, 0, 0, TimeSpan.Zero) });
sam.Children.Add(new() { Name = "Ella", Born = new(2020, 12, 24, 0, 0, 0, TimeSpan.Zero) });
// Get using Children list.
WriteLine($"Sam's first child is {sam.Children[0].Name}."); 
WriteLine($"Sam's second child is {sam.Children[1].Name}.");
// Get using the int indexer.
WriteLine($"Sam's first child is {sam[0].Name}."); 
WriteLine($"Sam's second child is {sam[1].Name}.");
// Get using the string indexer.
WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old.");
WriteLine("------------Pattern-matching flight passengers-----------------");
// An array containing a mix of passenger types.
Passenger[] passengers = {
  new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
  new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
  new BusinessClassPassenger { Name = "Janice" },
  new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
  new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
};
foreach (Passenger passenger in passengers)
{
  decimal flightCost = passenger switch
{
  /* C# 8 syntax
  FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
  FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
  FirstClassPassenger _                          => 2_000M, */
  // C# 9 or later syntax
  FirstClassPassenger p => p.AirMiles switch
  {
    > 35_000 => 1_500M,
    > 15_000 => 1_750M,
    _       => 2_000M
  },
  BusinessClassPassenger                        => 1_000M,
  CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
  CoachClassPassenger                           => 650M,
  _                                             => 800M
};
  WriteLine($"Flight costs {flightCost:C} for {passenger}");
}
WriteLine("------------Working with record types-----------------");
ImmutablePerson jeff = new() 
{
  FirstName = "Jeff",
  LastName = "Winger"
};
//This throws an error because the type is immutable
//jeff.FirstName = "Geoff";

WriteLine("------------Defining record types-----------------");
ImmutableVehicle car = new() 
{
  Brand = "Mazda MX-5 RF",
  Color = "Soul Red Crystal Metallic",
  Wheels = 4
};
ImmutableVehicle repaintedCar = car 
  with { Color = "Polymetal Grey Metallic" }; 
WriteLine($"Original car color was {car.Color}.");
WriteLine($"New car color is {repaintedCar.Color}.");

WriteLine("------------Equality of record types-----------------");
AnimalClass ac1 = new() { Name = "Rex" };
AnimalClass ac2 = new() { Name = "Rex" };
WriteLine($"ac1 == ac2: {ac1 == ac2}");
AnimalRecord ar1 = new() { Name = "Rex" };
AnimalRecord ar2 = new() { Name = "Rex" };
WriteLine($"ar1 == ar2: {ar1 == ar2}");

WriteLine("------------Positional data members in records-----------------");
ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar; // Calls the Deconstruct method.
WriteLine($"{who} is a {what}.");

WriteLine("------------Defining a primary constructor for a class-----------------");
Headset vp = new("Apple", "Vision Pro");
WriteLine($"{vp.ProductName} is made by {vp.Manufacturer}.");

Headset holo = new();
WriteLine($"{holo.ProductName} is made by {holo.Manufacturer}.");
Headset mq = new() { Manufacturer = "Meta", ProductName = "Quest 3" };
WriteLine($"{mq.ProductName} is made by {mq.Manufacturer}.");