namespace classes
{
  class Program
  {
    static void Main(string[] args)
    {
      var account = new BankAccount("Nash", 1000); // Create an account called nash with $1000 init
      Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance."); 

      //Testing withdrawals and deposits by creating 100 random deposits and withdrawals
      Random randSeed = new Random();
      for(int index=0; index<100; index++){
        int randNum = randSeed.Next(2);
        if (randNum==1){ // Make Deposit
          account.MakeDeposit(randSeed.Next(500), DateTime.Now,"testing");
        }else{ //Make WithDrawal
          int WithdrawalAmount=randSeed.Next(500);
          if ((account.Balance - WithdrawalAmount) > 0) // Ignore errors since Debugging function worked
          {
            account.MakeWithdrawal(WithdrawalAmount, DateTime.Now, "testing");
          }
        }
      }




      Console.WriteLine(account.GetAccountHistory());


      void Debugging(){ //Testing if errors are caught
        //Test that initial balnce mist be positive
        BankAccount invalidAccount;
        try
        {
          invalidAccount = new BankAccount("invalid", -55);
        }
        catch (ArgumentOutOfRangeException e) // Microsoft code catch (ArgumentOutOfRangeException e)
        {
          Console.WriteLine("Exception caught creating account with negative balance");
          Console.WriteLine(e.ToString()); 
          return;
        }
        // Testing for negative balance
        try
        {
          account.MakeWithdrawal(750, DateTime.Now, "Attemt to overdraw");
        }
        catch (InvalidOperationException e)
        {
          Console.WriteLine("Exception caught trying to overdraw");
          Console.WriteLine(e.ToString());
        }
      }
    }
  }
}
