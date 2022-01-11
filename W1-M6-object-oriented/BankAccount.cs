namespace classes
{
  public class BankAccount
  {
      /// <summary> 
      /// Number assigned to each account
      /// </summary>
    public string Number { get; }

    /// <summary> 
    /// Name of the owner of the account
    /// </summary>
    public string Owner { get; set; }


    /// <summary> 
    /// Balance of the account
    ///  </summary>
    public decimal Balance 
    { 
      get
      {
        decimal balance = 0;
        foreach (var item in allTransactions)
        {
          balance += item.Amount;
        }
        return balance;
      }
    }
    /// <summary> 
    /// Seed to assign all bank account classes a seed  
    /// </summary>
    private static int accountNumberSeed = 1234567890;  

    /// <summary> 
    /// Array containing all transactions 
    /// </summary>
    private List<Transaction> allTransactions = new List<Transaction>();  

    private readonly decimal minimumBalance;

    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
      {
    }

    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {

      this.Owner = name;
      this.Number = accountNumberSeed.ToString();
      this.minimumBalance = minimumBalance;
      accountNumberSeed++;

      if (initialBalance >0)
      {
          MakeDeposit(initialBalance, DateTime.Now, "initialBalance");
      }
    }
    /// <summary> 
    /// This function makes a deposit
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="date"></param>
    /// <param name="note"></param>
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
    }
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverDrawn)
    {
        if (isOverDrawn)
        {
            throw new InvalidOperationException("Not susfficient fund for this withdrawal");
        }
        else
        {
            return default;
        }
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
    public virtual void PerformMonthEndTransactions(){}

  }

}


