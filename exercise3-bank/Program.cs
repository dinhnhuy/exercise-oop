using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3_bank
{
    public class BankAccount
    {
        // TODO 1: Declare private fields (_balance, _pin, _failedAttempts)
        private decimal _balance; 
        private string _pin; 
        private int _failedAttempts; 

        // TODO 2: Declare public AccountHolder property (read-only)
        public string AccountHolder { get; } //

        // TODO 3: Declare IsLocked property with a private setter
        public bool IsLocked { get; private set; } 

        // Constructor
        public BankAccount(string accountHolder, decimal initialBalance, string initialPin)
        {
            AccountHolder = accountHolder; 
            _balance = initialBalance > 0 ? initialBalance : 0; 
            _pin = initialPin; 
            _failedAttempts = 0; 
            IsLocked = false; 
        }

        // TODO 4: Implement Deposit method
        public bool Deposit(decimal amount)
        {
            if (amount <= 0) 
            {
                Console.WriteLine("Error: Deposit amount must be positive."); 
                return false; 
            }

            _balance += amount; 
            Console.WriteLine($"Successfully deposited {amount:C}."); 
            return true;
        }

        // TODO 5: Implement Withdraw method
        public bool Withdraw(decimal amount, string inputPin)
        {
            if (IsLocked) 
            {
                Console.WriteLine("Error: Account is locked due to multiple failed PIN attempts."); //[cite: 1]
                return false; 
            }

            if (inputPin != _pin) 
            {
                _failedAttempts++; 
                if (_failedAttempts >= 3) 
                {
                    IsLocked = true; 
                    Console.WriteLine("Error: Invalid PIN code. Account has been LOCKED for security!"); 
                }
                else
                {
                    Console.WriteLine($"Error: Invalid PIN code. (Attempt {_failedAttempts}/3)"); 
                }
                return false; 
            }

            _failedAttempts = 0;

            if (amount <= 0 || amount > _balance) 
            {
                Console.WriteLine("Error: Invalid or insufficient funds."); 
                return false;
            }

            _balance -= amount; 
            Console.WriteLine($"Successfully withdrew {amount:C}.");
            return true;
        }

        // TODO 6: Implement GetBalance method (PIN required)
        public decimal GetBalance(string inputPin)
        {
            if (inputPin != _pin) 
            {
                Console.WriteLine("Error: Invalid PIN code."); 
                return -1m; 
            }
            return _balance; 
        }

        // TODO 7: Implement ChangePin method
        public bool ChangePin(string currentPin, string newPin)
        {
            if (currentPin != _pin) return false; 

            if (!string.IsNullOrEmpty(newPin) && newPin.Length == 4 && newPin.All(char.IsDigit)) 
            {
                _pin = newPin; 
                return true;
            }

            return false;
        }
    }
}
