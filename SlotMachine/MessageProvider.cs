using SlotMachine.Symbols;
using System;
using System.Collections.Generic;

namespace SlotMachine
{
    public static class MessageProvider
    {
        public static void RotationSymbols(this List<ISymbol> symbols)
        {
            symbols.ForEach(s => s.PrintSign());
            Console.WriteLine();
        }

        public static void EnterStake()
            => Console.WriteLine("Please stake money you would like to play with.");

        public static void EnterStakeInRange()
            => Console.WriteLine("Please enter amount of money that is greater than 0 and less than your deposit and balance.");

        public static void EnterDeposit()
            => Console.WriteLine("Please deposit money you would like to play with.");

        public static void DepositLimit(decimal depositLimit)
            => Console.WriteLine($"Please enter amount of money that is in the deposit limit (0 - {depositLimit}).");

        public static void ProfitAmount(decimal profitAmount)
            => Console.WriteLine($"You have won: {profitAmount}.");

        public static void CurrentBalance(decimal currentBalance)
            => Console.WriteLine($"Current balance is: {currentBalance}.");

        public static void EnterNumericAmount()
            => Console.WriteLine("Please enter a numeric value of money you would like to play with.(Example: 500)");

        public static void Separator()
            => Console.WriteLine();

        public static void EndGame()
            => Console.WriteLine("Would you like to end the game? (Please enter: Y for yes and N for No)");
    }
}
