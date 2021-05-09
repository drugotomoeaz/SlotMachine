using SlotMachine.SlotMachine.SlotMachine;

namespace SlotMachine.SlotMachine
{
    public class Player : IPlayer
    {
        public Player()
        {
            DepositAmount = 0;
            Balance = 0;
        }

        public decimal DepositAmount { get; private set; }

        public decimal Balance { get; private set; }

        public void CalculateBalance(decimal stakeAmount, decimal winAmount)
        {
            Balance = Balance - stakeAmount + winAmount;
        }

        public void DepositMoney(decimal depositAmount)
        {
            DepositAmount = depositAmount;
            Balance += depositAmount;
        }
    }
}
