using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Domain.Entities
{
    public class CashDispenser
    {


        private const int INITIAL_COUNT = 500;
        private int billCount;


        public CashDispenser()
        {
            billCount = INITIAL_COUNT;
        }


        public void DispenseCash(decimal amount)
        {

            int billsRequired = ((int)amount) / 20;
            billCount -= billsRequired;
        }


        public bool IsSufficientCashAvailable(decimal amount)
        {

            int billsRequired = ((int)amount) / 20;


            return (billCount >= billsRequired);
        }
    }
}

