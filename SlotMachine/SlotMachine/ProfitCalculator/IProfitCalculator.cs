using SlotMachine.Symbols;
using System.Collections.Generic;

namespace SlotMachine
{
    public interface IProfitCalculator
    {
        decimal GetProfit(ICollection<ISymbol> symbols, decimal stakeAmount);
    }
}
