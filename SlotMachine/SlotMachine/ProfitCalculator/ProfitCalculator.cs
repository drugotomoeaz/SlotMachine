using SlotMachine.Symbols;
using System.Collections.Generic;
using System.Linq;

namespace SlotMachine
{
    public class ProfitCalculator : IProfitCalculator
    {
        private static readonly object _lock = new object();
        private static IProfitCalculator _instance;

        private ProfitCalculator() { }

        public static IProfitCalculator CreateInstance()
        {
            lock (_lock)
            {
                if(_instance is null)
                {
                    _instance = new ProfitCalculator();
                }

                return _instance;
            }
        }

        public decimal GetProfit(ICollection<ISymbol> symbols, decimal stakeAmount)
            => DoSymbolsMatch(symbols)
                    ? CalculateProfit(symbols, stakeAmount)
                    : 0.0m;

        private static decimal CalculateProfit(ICollection<ISymbol> symbols, decimal stakeAmount)
            => symbols.Sum(s => s.Coefficient) * stakeAmount;

        private static bool DoSymbolsMatch(ICollection<ISymbol> symbols)
        {
            var distinctSymbols = symbols.Distinct().ToList();

            if (distinctSymbols.Count == 1)
                return true;
            
            return distinctSymbols.Count == 2 && 
                    distinctSymbols.ElementAt(0).Equals(distinctSymbols.ElementAt(1));
        }
    }
}
