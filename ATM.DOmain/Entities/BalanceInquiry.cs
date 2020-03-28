using ATM.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Domain.Entities
{
    public class BalanceInquiry : Transaction
    {
        private Screen screen;
        private BankDatabase bankDatabase;

        public BalanceInquiry(int accountNumber, decimal amount)
        {
            AccountNumber = accountNumber;
            Amount = amount;
        }

        public BalanceInquiry() { }

        public BalanceInquiry(int _AccountNumber, Screen screen, BankDatabase bankDatabase) : base(_AccountNumber)
        {
            this.screen = screen;
            this.bankDatabase = bankDatabase;
        }

        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }

    }
}
