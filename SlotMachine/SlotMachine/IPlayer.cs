namespace SlotMachine.SlotMachine.SlotMachine
{
    public interface IPlayer
    {
        decimal DepositAmount { get; }

        decimal Balance { get; }

        void CalculateBalance(decimal stakeAmount, decimal winAmount);

        void DepositMoney(decimal depositAmount);
    }
}