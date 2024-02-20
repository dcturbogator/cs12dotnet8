using Packt.Shared;
using System.Collections;

Person harry = new()
{
    Name = "Harry",
    Born = new(year: 2001, month: 3, day: 25,
        hour: 0, minute: 0, second: 0,
        offset: TimeSpan.Zero)
};
harry.WriteToConsole();
WriteLine("----------Implementing functionality using methods----------");
Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };
//Call the instance method to marry Lamech and Adah.
lamech.Marry(adah);
//Call the static method to marry Lamech and Zillah
//Person.Marry(lamech, zillah);
//Can also marry with the + operator, added a method to Person.cs to do this
if(lamech + zillah)
{
    WriteLine($"{lamech.Name} and {zillah.Name} successfully got married.");
}
lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();
//Call the instance method to make a baby.
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");
//Call the static method to make a baby.
Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";
//Use the * operator to "multiply".
Person baby3 = lamech * adah;
baby3.Name = "Jubal";
Person baby4 = zillah * lamech;
baby4.Name = "Naamah";
adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();
for (int i = 0; i < lamech.Children.Count; i++)
{
    WriteLine($"{lamech.Name}'s child #{i} is named \"{lamech.Children[i].Name}\".");
}
WriteLine("----------Working with non-generic types----------");
//Non generic lookup collection. These are considered a bad practice
// because they are not generic types, key can be anything.
Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");
int key = 2; // Look up the value that has 2 as its key.
WriteLine($"Key {key} has value: {lookupObject[key]}");
// Look up the value that has harry as its key
WriteLine($"Key {harry} has value: {lookupObject[key]}");
WriteLine("----------Working with generic types----------");
//Define a generic lookup collection, always use generics for collections.
// forget about the non-generic collections above.
Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");
key = 3;
WriteLine($"{key} has value {lookupIntString[key]}");
WriteLine("----------Defining and handling delegates----------");
// Assign the method to the Shout delegate
harry.Shout += Harry_Shout;
harry.Shout += Harry_Shout_2;
harry.Scream += Harry_Scream;
harry.Scream += Harry_Shout_2;
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();
WriteLine("----------Comparing objects when sorting----------");
Person?[] people = 
{
    null,
    new() { Name = "Simon" },
    new() { Name = "Jenny" },
    new() { Name = "Adam" },
    new() { Name = null },
    new() { Name = "Richard" },
    new() { Name = "Christopher "}
};
OutputPeopleNames(people, "Initial list of people:");
//Array.Sort(people);
OutputPeopleNames(people, "After sorting using Person's IComparable implementation:");
WriteLine("----------Comparing objects using a separate class----------");
Array.Sort(people, new PersonComparer());
OutputPeopleNames(people, "After soring using PersonComparer's IComparer implementation:");