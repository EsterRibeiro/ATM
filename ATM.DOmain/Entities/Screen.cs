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

       
        public string DisplayMessageLine(string message)
        {
            Console.WriteLine(message);
            return message;
        }


        public void DisplayDollarAmount(decimal amount)
        {
            Console.Write("{0:C}", amount);
        }
    }
}

