using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{

    using System;

    public class UserAccount
    {
        private string _password;
        private decimal _balance;

        // 1. AccountId 
        public string AccountId { get; private set; }

        // 2. Username
        public string Username { get; set; }

        // 3. Password
        public string Password
        {
            set { _password = "[ENCRYPTED]_" + value; }
        }

        // 4. Balance
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Error: Balance cannot be negative!");
                }
                else
                {
                    _balance = value;
                }
            }
        }

        // 5. IsVIP
        public bool IsVIP
        {
            get { return _balance > 10000; }
        }

        // 6. CreatedDate
        public DateTime CreatedDate { get; }

        // CONSTRUCTOR
        public UserAccount(string accountId, string username, string password)
        {
            AccountId = accountId; 
            Username = username;
            Password = password;
            CreatedDate = DateTime.Now;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            UserAccount user = new UserAccount("ACC-99201", "Alice_Code", "SuperSecretPassword123");

            Console.WriteLine($"Account ID: {user.AccountId}");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Account Created: {user.CreatedDate}");

            // 2. Test Balance Validation
            Console.WriteLine("\n--- Testing Balance Updates ---");
            user.Balance = 5000m;
            Console.WriteLine($"Current Balance: {user.Balance:C}");

            user.Balance = -200m;
            Console.WriteLine($"Current Balance after invalid attempt: {user.Balance:C}");

            // 3. Test IsVIP
            Console.WriteLine($"\nIs VIP? {user.IsVIP}");

            user.Balance = 15000m;
            Console.WriteLine($"Updated Balance: {user.Balance:C}");
            Console.WriteLine($"Is VIP now? {user.IsVIP}");
        }
    }
}
