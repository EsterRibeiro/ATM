using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBankATM.Models
{
    public class Saque
    {
        public Conta NumeroDaConta { get; set; }
        public decimal ValorDoSaque { get; set; }
        public DispensadorDeCedulas NotasDisponiveis { get; set; }

        public void EfetuarSaque() { }

       
    }
}
