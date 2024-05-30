
namespace BankNameSpace
{
    public class Bank : IBank
    {
        private readonly List<Account> accounts = new List<Account>();

        public float CalculateAllAccountsTotalBalance()
        {
            throw new NotImplementedException();
        }

        public void CreateAccount(Account account)
        {
            this.accounts.Add(account);
        }

        public string WithdrawMoney(long accountNumber, float money)
        {
            Account customer = FindAccount(accountNumber);

            float remaining_balance = customer.account_balance;
            if (remaining_balance - money < 500)
            {
                return "Insuficcient funds, the maintaining balance is 500";
            }

            customer.account_balance -= money;
            return $"Successfully withdrew ammount: {money}";
        }

        public string DepositMoney(long accountNumber, float money)
        {
            if (money < 500)
            {
                return "Insufficient amount, must be above 500";
            }

            Account customer = FindAccount(accountNumber);

            if (customer == null)
            {
                throw new ArgumentException("Invalid account number!", nameof(accountNumber));
            }

            customer.account_balance += money;
            return $"Succesfully deposited amount of {money}";
        }

        public Account FindAccount(long accountNumber)
        {
            Account customer = accounts.Find(x => x.account_number == accountNumber);
            if (customer == null)
            {
                throw new ArgumentException("Invalid account number!", nameof(accountNumber));
            }

            return customer;
        }

        public List<Account> GetAllAccounts()
        {
            return accounts;
        }
    }
}
