using System;
namespace Project11
{
    public class BankTransaction
    {
        private readonly decimal summa;
        private readonly DateTime when;
        public decimal Summa { get { return summa; } }
        public DateTime When { get { return when; } }
        public BankTransaction(decimal summa)
        {
            this.summa = summa;
            when = DateTime.Now;
        }
    }
}