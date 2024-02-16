namespace Packt.Shared;
public class BankAccount 
{
    public string? AccountName { get; set; }
    public decimal Balance { get; set; }
    public static decimal InterestRate { get; set; }
}