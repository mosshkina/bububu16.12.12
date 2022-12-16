#define DEBUG_ACCOUNT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project11
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 14.1");
            long num_acc = Bank.CreatAccount();
            BankAccount account = Bank.GetBankAccount(num_acc);
            account.Holder = "Mot";
            account.DumpToScreen();

            Console.WriteLine("Упражнение 14.2");
            Rational rational = new Rational();
            Type attrInfo = typeof(Rational);
            object[] attrs = attrInfo.GetCustomAttributes(false);
            DeveloperInfoAttribute developer_attr;
            developer_attr = (DeveloperInfoAttribute)attrs[0];
            Console.WriteLine($"Developer: {developer_attr.Developer}. Date:{developer_attr.Date}");

            Console.WriteLine("Домашнее задание 14.1");
            Building building = new Building();
            Type attr = typeof(Building);
            object[] attributes = attr.GetCustomAttributes(false);
            DeveloperAndOrganizationAttribute info;
            info = (DeveloperAndOrganizationAttribute)attributes[0];
            Console.WriteLine($"Developer: {info.Developer}. Organization: {info.Organization}");

            Console.ReadKey();
        }
        public static void TestPutMoney(BankAccount acc)
        {
            Console.WriteLine("Введите сумму, которую хотите положить на счёт");
            decimal sum;
            while (!decimal.TryParse(Console.ReadLine(), out sum))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            acc.PutMoney(sum);
        }
        public static void TestWithdrawMoney(BankAccount acc)
        {
            Console.WriteLine("Введите сумму, которую хотите снять со счёта");
            decimal sum;
            while (!decimal.TryParse(Console.ReadLine(), out sum))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            if (!acc.WithdrawMoney(sum))
            {
                Console.WriteLine("Невозможно снять данную сумму денег");
            }
        }
        static void PrintTransaction(BankAccount bank_account)
        {
            Console.WriteLine($"Transaction:");
            for (int counter = 0; counter < bank_account.Transaction().Count; counter++)
            {
                BankTransaction tran = bank_account[counter];
                Console.WriteLine($"Date/Time: {tran.When}. Summa: {tran.Summa}");
            }
        }
    }
}