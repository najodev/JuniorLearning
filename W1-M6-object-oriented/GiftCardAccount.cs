namespace classes
{

    public class GiftCardAccount : BankAccount
    {
        /// <summary> 
        /// The monthly deposit of account
        /// </summary> 
        private decimal _monthlyDeposit = 0m;

        /// <summary> 
        /// Constructor of gift card account
        /// </summary> 
        /// <param name="name">
        /// The name of the Gift card account
        /// </param> 
        /// <param name="initialBalance">
        /// The initial balance of the account
        /// </param> 
        /// <param name="monthlyDeposit">
        /// The monthly deposit of the account
        /// </param> 
        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance) => _monthlyDeposit = monthlyDeposit;

        /// <summary> 
        /// Method that will override class method to create a monthly deposit
        /// </summary> 
        public override void PerformMonthEndTransactions()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");

            }
        }
    }
}





