using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Creating a collection class using 



namespace Welcome1
{

    public class DaysOfTheWeek : IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        public IEnumerator GetEnumerator()
        {
            for (int a = 0; a < days.Length; a++)
            {
                // Yield each day of the week.
                yield return days[a];
            }
        }
    }








    class Program
    {
        static void Main(string[] args)
        {



            DaysOfTheWeek days = new DaysOfTheWeek();
            foreach(string day in days)
            {
                Console.WriteLine(day);
            }



            // Program.cs
            // The Main() method

           

        }
    }
}
