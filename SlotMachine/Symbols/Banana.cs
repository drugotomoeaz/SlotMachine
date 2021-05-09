namespace SlotMachine.Symbols
{
    public class Banana : Symbol
    {
        internal Banana()
        {
            Name = nameof(Banana);
            Sign = 'B';
            Coefficient = 0.6m;
            Probability = 0.35m;
        }
    }
}
