using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace testing_fundmentals
{
    public class BankAccount
    {
        private double _balance;

        public double Balance
        {
            get { return _balance; }
        }

        public string Owner { get; set; }

        public BankAccount(double initialBalance, string owner)
        {
            this.Owner = owner;
            this._balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            _balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > _balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            _balance -= amount;
        }

        public virtual string GetAccountType() => "Standard";
    }

    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }

        public SavingsAccount(double initialBalance, string owner, double interestRate) : base(initialBalance, owner)
        {
            this.InterestRate = interestRate;
        }

        public virtual void ApplyInterest()
        {
            double interestEarned = Balance * InterestRate;
            Deposit(interestEarned);
        }

        public override string GetAccountType()
        {
            return "Savings";
        }
    }
}
