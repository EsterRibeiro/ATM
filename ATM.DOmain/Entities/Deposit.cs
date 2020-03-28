using ATM.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Domain.Entities
{
    public class Deposit: Transaction
    {
        private int currentAccountNumber;
        private Screen screen;
        private BankDatabase bankDatabase;
        private Keypad keypad;
        private DepositSlot depositSlot;

        public Deposit(int accountNumber, decimal account)
        {
            AccountNumber = accountNumber;
            Account = account;
        }

        public Deposit() { }

        public Deposit(int currentAccountNumber, Screen screen, BankDatabase bankDatabase, Keypad keypad, DepositSlot depositSlot)
        {
            this.currentAccountNumber = currentAccountNumber;
            this.screen = screen;
            this.bankDatabase = bankDatabase;
            this.keypad = keypad;
            this.depositSlot = depositSlot;
        }

        public int AccountNumber { get; set; }
        public decimal Account { get; set; }


    }
}
