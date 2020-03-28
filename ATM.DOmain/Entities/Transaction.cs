using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Domain.Entities
{
    public abstract class Transaction
    {
        public Transaction(int _AccountNumber)
        {
            AccountNumber = _AccountNumber;

            CashDispenser = new CashDispenser();
            Keypad = new Keypad();
            Screen = new Screen();
            DepositSlot = new DepositSlot();
        }

        public Transaction() { }

        public int AccountNumber { get; private set; }

        protected Screen Screen { get; private set; } // ATM's screen
        protected Keypad Keypad { get; private set; } // ATM's keypad
        protected CashDispenser CashDispenser { get; private set; } // ATM's cash dispenser
        protected DepositSlot DepositSlot { get; private set; }

        public virtual void Execute() { }
    }
}

