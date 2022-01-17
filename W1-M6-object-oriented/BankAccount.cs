namespace classes
{
    /// <summary> 
    /// Create a new bankaccount
    /// </summary> 
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

        /// <summary> 
        /// The minimumBalance allowed on the account
        /// </summary> 
        private readonly decimal minimumBalance;

      
        /// <summary> 
        ///  Bank account constructor
        /// </summary> 
        /// <param name="name">
        /// This will be the bank account name
        /// </param>
        /// <param name="initialBalance">
        /// this is the inital balance oft he bankaccount
        /// </param>

        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
        {
        }

        /// <summary> 
        ///  Bank account constructor
        /// </summary> 
        /// <param name="name">
        /// This will be the bank account name
        /// </param>
        /// <param name="initialBalance">
        /// this is the inital balance oft he bankaccount
        /// </param>
        /// <param name="minimumBalance">
        /// The minimum allowed balance
        /// </param>
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
        /// <param name="amount">
        /// How much to deposit
        /// </param>
        /// <param name="date">
        /// The date of the deposit
        /// </param>
        /// <param name="note">
        /// notes on the deposit
        /// </param>
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {

                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of transactions must be positive");
            }
            var deposit= new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        /// <summary> 
        /// Method to make a withdrawal
        /// </summary> 
        /// <param name="amount">
        /// Amount of the withdrawal
        /// </param> 
        /// <param name="date">
        /// The date of the withdrawal
        /// </param> 
        /// <param name="note">
        /// Any notes on the withdrawal
        /// </param> 
        

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
        }

        /// <summary>
        /// Checks the withdrawal limit
        /// </summary>
        /// <param name="isOverDrawn">Whether or not its overdrawn</param>
        /// <returns>A Transaction</returns>
        /// <exception cref="InvalidOperationException">Fires this if overdrawn</exception>
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
        /// <summary> 
        /// Stores the account history in an array
        /// </summary> 

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
        /// <summary> 
        /// Method that can be overriden for end of month transactions
        /// </summary> 

        public virtual void PerformMonthEndTransactions()          {
        }

    }

}


