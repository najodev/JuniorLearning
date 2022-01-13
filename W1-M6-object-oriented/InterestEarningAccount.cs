namespace classes
{
    /// <summary>
    /// Interest Earning account class
    /// </summary>
    public class InterestEarningAccount : BankAccount {

        /// <summary> 
        /// Interest Earning Account method
        /// </summary> 
        /// <param name="name">
        /// name of the account
        /// </param> 
        /// <param name="initialBalance">
        /// The inital balance of the account
        /// </param> 

        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
        }

        /// <summary> 
        /// Overide method for end of month transactions
        /// </summary> 

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }
    }
}

