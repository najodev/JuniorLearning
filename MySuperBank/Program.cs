using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Evan", 1000);
            Console.WriteLine($"Account {account.Number} was for {account.Owner} with {account.Balance}");
        }
    }
}
