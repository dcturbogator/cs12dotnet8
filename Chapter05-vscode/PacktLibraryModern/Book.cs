using System.Diagnostics.CodeAnalysis; // To use [SetsRequiredMembers].

namespace Packt.Shared;

public class Book
{
    public required string? Isbn { get; set; }
    public required string? Title { get; set; }
    public string? Author { get; set; }
    public int PageCount { get; set; }

    // Constructor for use with object initializer syntax
    public Book() { }

    // Constructor with parameters to set required fields.
    [SetsRequiredMembers]
    public Book(string? isbn, string? title)
    {
        Isbn = isbn;
        Title = title;
    }
}
