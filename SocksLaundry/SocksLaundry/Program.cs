using SocksLaundryLib;
using System;

namespace SocksLaundry
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberMachineCanWash = 5;
            int[] cleanPile = new int[] { 1, 2, 3, 2, 3, 4, 5 };
            int[] dirtyPile = new int[] { 2, 1, 1, 1, 3, 3, 3, 4, 4, 4, 5, 5, 6, 5, 7, 5, 6 };
            int pairs = new ClassLib().GetMaximumPairOfSocks(numberMachineCanWash, cleanPile, dirtyPile);
            Console.WriteLine(pairs);
        }
    }
}
