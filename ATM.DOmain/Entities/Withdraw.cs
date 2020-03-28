using ATM.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Domain.Entities
{
    public class Withdrawal : Transaction
    {
        private Screen screen;
        private BankDatabase bankDatabase;
        private Keypad keypad;
        private CashDispenser cashDispenser;

        public Withdrawal(int accountNumber, decimal amount)
        {
            AccountNumber = accountNumber;
            Amount = amount;
        }

        public Withdrawal() { }

        public Withdrawal(int _AccountNumber, Screen screen, BankDatabase bankDatabase, Keypad keypad, CashDispenser cashDispenser) : base(_AccountNumber)
        {
            this.screen = screen;
            this.bankDatabase = bankDatabase;
            this.keypad = keypad;
            this.cashDispenser = cashDispenser;
        }

        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }

    }
}
