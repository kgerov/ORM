using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            ATMEntities cx = new ATMEntities();

            using (var dbContextTransaction = cx.Database.BeginTransaction())
            {
                try
                {               
                    Console.Write("Enter card number: ");
                    string cardNumber = Console.ReadLine();
                    var card = cx.CardAccounts
                        .Where(x => x.CardNumber == cardNumber)
                        .FirstOrDefault();                 

                    if (card == null)
                    {
                        Console.WriteLine("No such card number...");
                        throw new Exception("No such card number...");
                    }

                    Console.Write("Enter pin: ");
                    string pin = Console.ReadLine();

                    if (card.CardPin != pin)
                    {
                        Console.WriteLine("Invalid pin...");
                        throw new Exception("Invalid pin...");
                    }

                    Console.Write("How much money you want to withdraw: ");
                    decimal money = Decimal.Parse(Console.ReadLine());

                    if (money < 0 || money > card.CardCash)
                    {
                        Console.WriteLine("Not enough money in account");
                        throw new Exception("Not enough money in account");
                    }

                    Console.WriteLine("Here is your money " + money);
                    card.CardCash -= money;

                    cx.TransactionHistories.Add(new TransactionHistory
                    {
                        CardNumberId = card.Id,
                        TransactionDate = DateTime.Now,
                        Amount = money
                    });

                    cx.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }

        }
    }
}
