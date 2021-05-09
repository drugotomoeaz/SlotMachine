using SlotMachine.SlotMachine.SlotMachine;
using SlotMachine.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlotMachine.SlotMachine
{
    public class Game : IGame
    {
        private const decimal depositLimit = 1000;

        private readonly ISymbolRandomizer _randomizer;

        private readonly IProfitCalculator _profitCalculator;

        private readonly ICollection<ISymbol> _symbols;

        private readonly IPlayer _player;

        public Game(IProfitCalculator profitCalculator, IPlayer player)
        {
            _profitCalculator = profitCalculator;
            _symbols = CreateSymbols();
            _randomizer = new SymbolRandomizer(_symbols);
            _player = player;
        }

        public void Start()
        {
            do 
            {
                Play();
            }
            while (!EndGame());

            Environment.Exit(0);
        }

        private void Play()
        {
            MessageProvider.EnterDeposit();
            _player.DepositMoney(GetDepositMoney());
            MessageProvider.Separator();

            while (_player.Balance > 0)
            {
                Spin();
            }
        }

        private decimal GetDepositMoney()
        {
            decimal depositAmount;

            var deposit = Console.ReadLine();
            while (!Decimal.TryParse(deposit, out depositAmount))
            {
                MessageProvider.EnterNumericAmount();
                deposit = Console.ReadLine();
            }

            if(depositAmount > depositLimit || depositAmount < 0)
            {
                MessageProvider.DepositLimit(depositLimit);
                depositAmount = GetDepositMoney();
            }

            return depositAmount;
        }

        private decimal GetStakeAmount()
        {
            decimal stakeAmount;

            var stake = Console.ReadLine();
            while (!Decimal.TryParse(stake, out stakeAmount))
            {
                MessageProvider.EnterNumericAmount();
                stake = Console.ReadLine();
            }

            if(stakeAmount > _player.Balance || stakeAmount < 0)
            {
                MessageProvider.EnterStakeInRange();
                stakeAmount = GetStakeAmount();
            }

            return stakeAmount;
        }

        private void RotateSymbols(decimal stakeAmount, ref decimal winningAmount)
        {
            var rotationSequence = _randomizer.GetSample(3);

            winningAmount += _profitCalculator.GetProfit(rotationSequence, stakeAmount);
            MessageProvider.RotationSymbols(rotationSequence.ToList());
        }

        private void Spin()
        {
            MessageProvider.EnterStake();
            var stakeAmount = GetStakeAmount();
            MessageProvider.Separator();

            var winningAmount = 0.0m;
            var rotationCount = 4;

            while (rotationCount > 0)
            {
                RotateSymbols(stakeAmount, ref winningAmount);
                rotationCount--;
            }

            _player.CalculateBalance(stakeAmount, winningAmount);
            MessageProvider.Separator();
            MessageProvider.ProfitAmount(winningAmount);
            MessageProvider.CurrentBalance(_player.Balance);
            MessageProvider.Separator();
        }

        private static ICollection<ISymbol> CreateSymbols()
        {
            var symbols = new List<ISymbol>();

            foreach (var symbol in Enum.GetValues(typeof(Symbols.Symbols)))
            {
                symbols.Add(Symbol.Create((Symbols.Symbols)symbol));
            }

            return symbols;
        }

        private bool EndGame()
        {
            MessageProvider.Separator();
            MessageProvider.EndGame();
            var answer = Console.ReadKey();
            MessageProvider.Separator();

            if ("yY".Contains(answer.KeyChar))
                return true;
            else if ("nN".Contains(answer.KeyChar))
                return false;
            else
                return EndGame();
        }
    }
}
