using System;

namespace BranchesIF
{
    class Class1
    {
        static void Main(string[] args)
        {
            var names = new List<string> { "<name>", "Ana", "Felipe" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
                foreach (var name in names)
                {
                    System.Console.WriteLine($"Hello {name}");
                }


            }

        }
    }
}



	}
}
