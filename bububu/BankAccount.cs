using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.IO;
using System.Diagnostics;


namespace Project11
{
    public enum AccountType { Actual, Savings };
    sealed class BankAccount : IDisposable
    {
        private long number;
        private decimal balance;
        private AccountType accountType;
        private Queue transaction_queue = new Queue();
        bool disposed = false;
        private string holder;
        internal BankAccount()
        {
            number = 1;
        }
        internal BankAccount(AccountType accountType)
        {
            this.accountType = accountType;
            balance = 1000;
        }
        internal BankAccount(decimal balance)
        {
            this.balance = balance;
        }
        internal BankAccount(AccountType accountType, decimal balance)
        {
            this.accountType = accountType;
            this.balance = balance;
        }
        public long Number { get { return number; } }
        public string Type { get { return accountType.ToString(); } }
        public string Holder { get { return holder; } set { holder = value; } }
        public decimal Balance()
        {
            return balance;
        }
        public decimal PutMoney(decimal summa)
        {
            balance += summa;
            BankTransaction account_tran = new BankTransaction(summa);
            transaction_queue.Enqueue(account_tran);
            return balance;
        }
        public bool WithdrawMoney(decimal summa)
        {
            bool examination = (balance >= summa);
            if (examination)
            {
                balance -= summa;
                BankTransaction account_tran = new BankTransaction(-summa);
                transaction_queue.Enqueue(account_tran);
            }
            return examination;
        }
        [Conditional("DEBUG_ACCOUNT")]
        public void DumpToScreen()
        {
            Console.WriteLine($"Debugging account {this.number}. Holder is {this.holder}. Type is {this.accountType}. Balance is {this.balance}");
        }
        public Queue Transaction()
        {
            return transaction_queue;
        }
        public void Dispose()
        {
            if (!disposed)
            {
                StreamWriter file_info = File.AppendText("Transactions.txt");
                file_info.WriteLine($"Account number:{number}");
                file_info.WriteLine($"Account balance:{balance}");
                file_info.WriteLine($"Account type: {accountType}");
                file_info.WriteLine("Transaction:");
                foreach (BankTransaction tran in transaction_queue)
                {
                    file_info.WriteLine($"Date/Time: {tran.When}. Summa: {tran.Summa}");
                }
                file_info.Close();
                disposed = true;
                GC.SuppressFinalize(this);
            }
        }
        ~BankAccount()
        {
            Dispose();
        }
        public BankTransaction this[int index]
        {
            get
            {
                if (index < 0 || index >= transaction_queue.Count)
                {
                    return null;
                }
                IEnumerator ie = transaction_queue.GetEnumerator();
                for (int i = 0; i <= index; i++)
                {
                    ie.MoveNext();
                }
                BankTransaction tran = (BankTransaction)ie.Current;
                return tran;
            }
        }
        public void PrintValues()
        {
            Console.WriteLine($"Account number: {number}");
            Console.WriteLine($"Account balance: {balance}");
            Console.WriteLine($"Account type: {accountType}");
            Console.WriteLine($"Account holder: {holder}");
        }
    }
}