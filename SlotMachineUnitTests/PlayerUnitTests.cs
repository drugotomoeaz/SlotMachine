using NUnit.Framework;
using SlotMachine.SlotMachine;
using SlotMachine.SlotMachine.SlotMachine;

namespace SlotMachine.UnitTests
{
    public class PlayerUnitTests
    {
        private IPlayer _player;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(10, 125, 115)]
        [TestCase(100, 598, 498)]
        [TestCase(99, 10, -89)]
        public void CalculateBalance_PositiveAmounts_CorrectBalance(decimal stakeAmount, decimal winAmount, decimal expectedResult)
        {
            _player = new Player();

            _player.CalculateBalance(stakeAmount, winAmount);

            Assert.AreEqual(expectedResult, _player.Balance);
        }

        [Test]
        [TestCase(-10, 125, 135)]
        [TestCase(-100, -598, -498)]
        [TestCase(99, 0, -99)]
        public void CalculateBalance_NegativeAmounts_CorrectBalance(decimal stakeAmount, decimal winAmount, decimal expectedResult)
        {
            _player = new Player();

            _player.CalculateBalance(stakeAmount, winAmount);

            Assert.AreEqual(expectedResult, _player.Balance);
        }

        [Test]
        [TestCase(10, 10)]
        [TestCase(999, 999)]
        [TestCase(-12, -12)]
        public void DepositMoney_DifferentAmounts_CorrectDeposit(decimal depositAmount, decimal expectedResult)
        {
            _player = new Player();

            _player.DepositMoney(depositAmount);

            Assert.AreEqual(expectedResult, _player.DepositAmount);
        }
    }
}
