namespace BankNameSpace
{
    public class Account : Bank, IAccount
    {
        public long account_number;
        private string account_name;
        public float account_balance;

        public Account(long account_number, string account_name, float account_balance)
        {
            this.account_number = account_number;
            this.account_name = account_name;
            this.account_balance = account_balance;
        }

        public string DisplayAccountDetails()
        {
            return $"Name: {this.account_name} \nAcct Number: {this.account_number}\nBalance: {this.account_balance}";
        }

        public float GetAccountBalance()
        {
            return this.account_balance;
        }

        
    }
}
