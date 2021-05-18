using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
   public class BankAccount
    {
        public string Number { get; }
        public String Owner { get; set; }
        public decimal Balance
        { 
            get
            {
                    decimal balance = 0;
                    foreach (var item in allTransactions)
                    {
                        balance = balance + item.Amount;

                    }
                    return balance;
                
            }
        }

        private static int accountNumberSeed = 1131331413;
         
        private List<Transaction> allTransactions = new List<Transaction>();
        public BankAccount(string name)
        {
            Owner = name;
           
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        { 
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);

        }




        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {

                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }


            if (Balance - amount <= 0)
            {

                throw new ArgumentOutOfRangeException(nameof(amount), "Dont have enough funds available");
            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);


        }   

    }
}
