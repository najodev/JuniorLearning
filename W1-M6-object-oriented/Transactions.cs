
namespace classes
{
    /// <summary> 
    /// Create a new transaction
    /// </summary> 
    public class Transaction
    {

        public decimal Amount { get; } 
        public DateTime Date { get; }
        public string Notes { get; }
        /// <summary> 
        /// Method to create a new transaction
        /// </summary> 
        /// <param name="amount">
        /// The amount of the transaction
        /// </param> 
        /// <param name="date">
        /// The date of the transaction
        /// </param> 
        /// <param name="note">
        /// notes on the transaction
        /// </param> 
        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount=amount; 
            this.Date=date;
            this.Notes=note;
        }

    }
}
