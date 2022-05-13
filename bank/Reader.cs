using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Reader
    {
        public static List<User> readUsersFromFile(string file)
        {
            return File.ReadAllLines(file).Skip(1).Select(v => createUser(v)).ToList();
        }
        public static User createUser(string row)
        {
            string[] values = row.Split(";");
            User user = new User();
            user.Id = int.Parse(values[0]);
            user.Name = values[1];
            user.Surname = values[2];
            user.Pesel = values[3];
            user.Address = values[4];
            return user;
        }
        public static List<Account> readAccountsFromFile(string file)
        {
            return File.ReadAllLines(file).Skip(1).Select(v => createAccount(v)).ToList();
        }
        public static Account createAccount(string row)
        {
            string[] values = row.Split(";");
            Account account = new Account();
            account.AccountNumber = values[0];
            account.UserId = int.Parse(values[1]);
            account.Balance = double.Parse(values[3]);
            account.IsBlocked = bool.Parse(values[4]);
            account.Currency = (CurrencyEnum)Enum.Parse(typeof(CurrencyEnum), values[2], true);
            return account;
        }
    }
}
