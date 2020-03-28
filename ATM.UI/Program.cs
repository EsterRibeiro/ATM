using ATM.Domain.Entities;
using System;

namespace ATM.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Atm theAtm = new Atm();
            theAtm.Run();
        }
    }
}
