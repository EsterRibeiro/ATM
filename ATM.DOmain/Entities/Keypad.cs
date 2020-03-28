using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Domain.Entities
{
    public class Keypad
    {
        public int GetInput()
        {
            return Convert.ToInt32(Console.ReadLine());
        } 
    }
}
