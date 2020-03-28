using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBankATM.Models
{
    public class Conta
    {
        public Conta(int numeroConta, int pIN)
        {
            NumeroConta = numeroConta;
            PIN = pIN;
        }

        public Conta() { }

        public int NumeroConta { get; set; }
        private int PIN { get; set; }
        
        public void AutenticacaoConta() { }
        public bool ValidarPIN()
        {

        }
    }
}
