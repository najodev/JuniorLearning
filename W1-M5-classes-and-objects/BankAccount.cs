using System;
using System.Collections.Generic;

namespace classes
{
  public class BankAccount
  {
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance 
    { 
      get
      {
        decimal balance = 0;
        foreach (var item in allTransactions) // Loop through allTransactions and return the correct balance
        {
          balance += item.Amount;
        }
        return balance;
      }
    }
    private static int accountNumberSeed = 1234567890;  // A Seed that allows for each account to have an account Number
    private List<Transaction> allTransactions = new List<Transaction>();  // Array with full list of past transactions


    public BankAccount(string name, decimal initialBalance)
    {

      this.Owner = name;
      this.Number = accountNumberSeed.ToString();
      accountNumberSeed++;

      MakeDeposit(initialBalance, DateTime.Now, "initialBalance");
    }


    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
      if (amount <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of transactions must be positive");
      }
      var deposit= new Transaction(amount, date, note);
      allTransactions.Add(deposit);
    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
      if (amount <=0)
      {
        throw new ArgumentOutOfRangeException(nameof(amount), "amount of withdrawal must be positive");
      }
      if (Balance - amount < 0)
      {
        throw new InvalidOperationException("Not sufficient funds for this withdrawal");
      }
      var withdrawal = new Transaction(-amount, date, note);
      allTransactions.Add(withdrawal);
    }
    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in allTransactions)
        {
          balance += item.Amount;
          report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }
        return report.ToString();
    }

  }

}


