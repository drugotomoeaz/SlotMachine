namespace SlotMachine.Symbols
{
    public class Pineapple : Symbol
    {
        internal Pineapple()
        {
            Name = nameof(Pineapple);
            Sign = 'P';
            Coefficient = 0.8m;
            Probability = 0.15m;
        }
    }
}
