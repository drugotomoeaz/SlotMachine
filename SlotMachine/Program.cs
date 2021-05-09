using SlotMachine.SlotMachine;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(ProfitCalculator.CreateInstance(), new Player());
            game.Start();
        }
    }
}
