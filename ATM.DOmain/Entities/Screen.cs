using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Domain.Entities
{
    public class Screen
    {
        
        public void DisplayMessage(string message)
        {
            Console.Write(message);
        } 

       
        public void DisplayMessageLine(string message)
        {
            Console.WriteLine(message);
        }


        public void DisplayDollarAmount(decimal amount)
        {
            Console.Write("{0:C}", amount);
        }
    }
}

