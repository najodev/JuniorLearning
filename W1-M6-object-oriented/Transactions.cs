
namespace classes
{
    /// <summary> 
    /// Create a new transaction
    /// </summary> 
    public class Transaction
    {
        /// <summary>
        /// Represents the amount
        /// </summary>
        public decimal Amount { get; } 

        /// <summary>
        /// Represents the date of the transaction
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Notes about the transaction
        /// </summary>
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
