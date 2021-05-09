using SlotMachine.Symbols;
using System.Collections.Generic;

namespace SlotMachine
{
    public interface ISymbolRandomizer
    {
        ICollection<ISymbol> GetSample(int size);
    }
}