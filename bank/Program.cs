using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bank
{
    class Program
    {
        static void Main(string[] args)
        {
            User.user = Reader.readUsersFromFile("osoby.csv");
            Account.account = Reader.readAccountsFromFile("konta.csv");
            bool x = true;
            while (x)
            {
                Console.WriteLine("Wybierz opcje:");
                Console.WriteLine("1. Lista kont użytkownika");
                Console.WriteLine("2. Wpłaty i wypłaty z konta");
                Console.WriteLine("3. Lista użytkowników zablokowanych");
                Console.WriteLine("4. Raport o użytkownikach wraz z saldem na poszczególnych kontach");
                Console.WriteLine("5. Wyjdź z programu");
                var choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        Console.WriteLine("Podaj id użytkownika: ");
                        var userId = int.Parse(Console.ReadLine());
                        var filteredAccounts = Account.account.Select(a => a).Where(a => a.UserId == userId).ToArray();
                        foreach (var account in filteredAccounts)
                        {
                            Console.WriteLine($"Numer konta: {account.AccountNumber} saldo: {account.Balance} {account.Currency} czy zablokowane? {account.IsBlocked}");
                        }
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        break;
                    case "2":
                        Console.WriteLine("Podaj id użytkownika: ");
                        var userPayment = int.Parse(Console.ReadLine());
                        var userAccounts = Account.account.Where(x => x.UserId == userPayment).ToList();
                        Console.WriteLine("Wybierz konto: ");
                        for (int i = 0; i < userAccounts.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Numer konta: {userAccounts[i].AccountNumber} saldo: {userAccounts[i].Balance} {userAccounts[i].Currency}");
                        }
                        var chooseAccount = int.Parse(Console.ReadLine());
                        var currentAccount = userAccounts[chooseAccount - 1];
                        Console.WriteLine("Wybierz opcje:");
                        Console.WriteLine("1. Wpłata");
                        Console.WriteLine("2. Wypłata");
                        var money = int.Parse(Console.ReadLine());
                        if (money == 1)
                        {
                            Console.WriteLine("Podaj kwotę do wpłaty: ");
                            var amount = double.Parse(Console.ReadLine());
                            Account.account.Select(x => x).Where(x => x.AccountNumber == currentAccount.AccountNumber).First().Balance = currentAccount.Balance + amount;
                            Console.WriteLine($"Dokonano wpłaty pomyślnie! Stan konta: {currentAccount.Balance} {currentAccount.Currency}");
                        }
                        if (money == 2)
                        {
                            Console.WriteLine("Podaj kwotę do wypłaty: ");
                            var amount = double.Parse(Console.ReadLine());
                            Account.account.Select(x => x).Where(x => x.AccountNumber == currentAccount.AccountNumber).First().Balance = currentAccount.Balance - amount;
                            Console.WriteLine($"Dokonano wypłaty pomyślnie! Stan konta: {currentAccount.Balance} {currentAccount.Currency}");
                        }
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        break;
                    case "3":
                        var blockedAccounts = Account.account.Where(x => x.IsBlocked == true).ToList();
                        Console.WriteLine("Wykaz zablokowanych kont:");
                        foreach (var account in blockedAccounts)
                        {
                            Console.WriteLine($"Użytkownik: {account.UserId} numer konta: {account.AccountNumber} saldo: {account.Balance} {account.Currency}");

                        }
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        break;
                    case "4":
                        Console.WriteLine("Raport kont użytkowników z saldem na poszczególnych kontach:");
                        foreach (var user in User.user)
                        {
                            var usersAccounts = Account.account.Where(x => x.UserId == user.Id).ToList();
                            Console.WriteLine($"Konta użytkownika: {user.Name} {user.Surname} id: {user.Id}");
                            foreach (var account in usersAccounts)
                            {
                                Console.WriteLine($"Konto numer: {account.AccountNumber} saldo: {account.Balance} {account.Currency}"); ;
                            }
                        }
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        break;
                    case "5":
                        x = false;
                        break;
                    default:
                        Console.WriteLine("Wybrales zla opcje");
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        break;
                }
            };
        }
    }
}
