namespace SlotMachine.Symbols
{
    public class Wildcard : Symbol
    {
        internal Wildcard()
        {
            Name = nameof(Wildcard);
            Sign = '*';
            Coefficient = 0.0m;
            Probability = 0.05m;
        }

        public override bool Equals(ISymbol otherSymbol)
            => otherSymbol != null;
    }
}