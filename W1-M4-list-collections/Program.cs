// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

void WorkWithString()
{
  var names = new List<string> { "Nash", "Ana", "Kaz", "Donny", "Ana" };
  foreach (var name in names)
  {
    Console.WriteLine($"Hello {name.ToUpper()}!");
  }

  Console.WriteLine();
  names.Add("Maria");
  names.Add("Bill");
  names.Remove("Ana");
  /*foreach (var name in names)
    { 
    Console.WriteLine($"Hello {name.ToUpper()}!");
    }

    Console.WriteLine($"My name is {names[0]}");
    Console.WriteLine($"I've added {names[2]} and {names[3]}");

    Console.WriteLine($"The list has {names.Count} people in it");

*/

  var index = names.IndexOf("Felipe");
  if (index == -1)
  {
    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
  }
  else
  {
    Console.WriteLine($"The name {names[index]} is at index {index}");
  }
  names.Sort();
  foreach (var name in names)
  {
    Console.WriteLine($"Hello {name.ToUpper()}!");
  }
}


var fibonacciNumbers = new List<int> {1, 1};
for (int FibIndex = 1; FibIndex <= 18; FibIndex++)
{
int previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
int previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
fibonacciNumbers.Add(previous + previous2);
}


for (int FibIndex = 1; FibIndex <= 20; FibIndex++)
{
  Console.WriteLine($"{FibIndex}: {fibonacciNumbers[FibIndex-1]}");

}