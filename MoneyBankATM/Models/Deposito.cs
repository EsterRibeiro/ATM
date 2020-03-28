using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBankATM.Models
{
    public class Deposito
    {
        public Conta NumeroDaConta { get; set; }
        public decimal ValorDepositado { get; set; }

        public void EfetuarDeposito()
        {

        }
    }
}
