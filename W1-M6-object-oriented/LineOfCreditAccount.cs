namespace classes
{
    /// <summary> 
    /// Line of credit account class
    /// </summary> 
    public class LineOfCreditAccount : BankAccount
    {

        /// <summary> 
        /// Method for line of credit account
        /// </summary> 
        /// <param name="name">
        /// The name of the account
        /// </param> 
        /// <param name="initalBalance">
        /// The initial Balance of the account
        /// </param> 
        /// <param name="creditLimit">
        /// The limit of credit permitted on the account
        /// </param> 

        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance -creditLimit)
        {
        }

        /// <summary> 
        /// Overide method for end of month tansactions
        /// </summary> 
        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }

        }

        /// <summary> 
        /// Method to checkWithdrawalLimit
        /// </summary> 
        /// <param name="isOverDrawn">
        /// Boolean of if the account has overdrawn money
        /// </param> 
        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
            isOverdrawn
            ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
            : default;
    }
}

