using System;

namespace SlotMachine.Symbols
{
    public interface ISymbol : IEquatable<ISymbol>
    {
        string Name { get; }

        char Sign { get; }

        decimal Coefficient { get; }

        decimal Probability { get; }

        void PrintSign();
    }
}