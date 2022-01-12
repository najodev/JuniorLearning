Interpolation

use: 
Console.WriteLine($"This is a interpolation {variable}")

These string can be formatted on the output using

$"{variable:format}"

formats

d - standard date and time format string dd/mm/yyyy
t - standard short time hh:mm
C2 - shows currency value with 2 cent places

https://docs.microsoft.com/en-au/dotnet/standard/base-types/formatting-types#format-strings-and-net-types


Use a comma after the variable name to make use allginment and insert white spaces wherre necessary

{variable, amount }

if amount is negative allign left.
