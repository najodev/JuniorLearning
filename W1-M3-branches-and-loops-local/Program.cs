﻿using System;

//ExploreIf();

void ExploreIf()
{
  int a = 5;
  int b = 3;
  if (a + b > 10)
  {
    Console.WriteLine("The answer is greater than 10");
  }
  else
  {
    Console.WriteLine("The answer is not greater than 10");
  }

  int c = 4;
  if ((a + b + c > 10) && (a > b))
  {
    Console.WriteLine("The answer is greater than 10");
    Console.WriteLine("And the first number is greater than the second");
  }
  else
  {
    Console.WriteLine("The answer is not greater than 10");
    Console.WriteLine("Or the first number is not greater than the second");
  }

  if ((a + b + c > 10) || (a > b))
  {
    Console.WriteLine("The answer is greater than 10");
    Console.WriteLine("Or the first number is greater than the second");
  }
  else
  {
    Console.WriteLine("The answer is not greater than 10");
    Console.WriteLine("And the first number is not greater than the second");
  }
}

/*
 * int counter = 0;
do
{
  Console.WriteLine($"Hello World! The counter is {counter}");
  counter++;
} while (counter < 10);
*/

/*
for (int index=0; index < 10; index++)
{
  Console.WriteLine($"Hello World! The index is {index}");
}
*/
/*
 for (int row = 1; row < 11; row++)
{
    for (char column = 'a'; column < 'k'; column++)
    {
        Console.WriteLine($"The cell is ({row}, {column})");
    }
}
*/


//Find the numbers divisible by 3 from 1 to 20
int sumOf = 0;
for (int dividend=0; dividend<20; dividend++)
{
 if ((dividend % 3) == 0)
  {
    sumOf=sumOf+dividend;
  }
}
Console.WriteLine(sumOf);

  


