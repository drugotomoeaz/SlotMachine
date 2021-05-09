namespace SlotMachine.Symbols
{
    public class Apple: Symbol
    {
        internal Apple()
        {
            Name = nameof(Apple);
            Sign = 'A';
            Coefficient = 0.4m;
            Probability = 0.45m;
        }
    }
}
