namespace BankNameSpace
{
    internal interface IBank
    {
        public void CreateAccount(Account account); 
        public Account FindAccount(long accountNumber);
        public string DepositMoney(long account_number, float money);
        public string WithdrawMoney(long accountNumber, float money);
        public List<Account> GetAllAccounts();
        public float CalculateAllAccountsTotalBalance();
    }
}
