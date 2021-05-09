using System;

namespace SlotMachine.Symbols
{
    public abstract class Symbol : ISymbol
    {
        public string Name { get; protected set; }

        public char Sign { get; protected set; }

        public decimal Coefficient { get; protected set; }

        public decimal Probability { get; protected set; }

        public void PrintSign()
            => Console.Write(Sign);

        public override int GetHashCode()
            => Name.GetHashCode() ^ Sign.GetHashCode() ^ Coefficient.GetHashCode() ^ Probability.GetHashCode();

        public virtual bool Equals(ISymbol otherSymbol)
        {
            if (otherSymbol != null)
                return otherSymbol.GetType().FullName == typeof(Wildcard).FullName || 
                       otherSymbol.GetType().FullName == this.GetType().FullName;
            else
                return false;
        }

        public static Symbol Create(Symbols symbol)
        {
            return symbol switch
            {
                Symbols.Apple => new Apple(),
                Symbols.Banana => new Banana(),
                Symbols.Pineapple => new Pineapple(),
                Symbols.Wildcard => new Wildcard(),
                _ => throw new ArgumentException("There is no matching symbol to be instantiated."),
            };
        }
    }
}
