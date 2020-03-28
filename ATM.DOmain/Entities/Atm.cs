using ATM.Infra;
using static ATM.Domain.Entities.BalanceInquiry;

namespace ATM.Domain.Entities
{
    public class Atm
    {
        private bool userAuthenticated; 
        private int currentAccountNumber; 
        public Screen screen; 
        private Keypad keypad; 
        private CashDispenser cashDispenser; 
        private DepositSlot depositSlot; 
        private BankDatabase bankDatabase;

        public Atm(bool userAuthenticated, int currentAccountNumber, Keypad keypad, CashDispenser cashDispenser, DepositSlot depositSlot, BankDatabase bankDatabase)
        {
            this.userAuthenticated = userAuthenticated;
            this.currentAccountNumber = currentAccountNumber;
            this.keypad = keypad;
            this.cashDispenser = cashDispenser;
            this.depositSlot = depositSlot;
            this.bankDatabase = bankDatabase;
        }

        public Atm() { }

        private enum MenuOption
        {
            BALANCE_INQUIRY = 1,
            WITHDRAWAL = 2,
            DEPOSIT = 3,
            EXIT_ATM = 4
        } 
       


        
        public void Run()
        {
            
            while (true) 
            {
                
                while (!userAuthenticated)
                {
                    
                    screen.DisplayMessageLine("\nWelcome!");
                    AuthenticateUser(); 
                }

                PerformTransactions(); 
                userAuthenticated = false; 
                currentAccountNumber = 0; 
                screen.DisplayMessageLine("\nThank you! Goodbye!");
            } 
        } 

        
        private void AuthenticateUser()
        {
            
            screen.DisplayMessage("\nPlease enter your account number: ");
            int accountNumber = keypad.GetInput();


            screen.DisplayMessage("\nEnter your PIN: ");
            int pin = keypad.GetInput();


            userAuthenticated =
               bankDatabase.AuthenticateUser(accountNumber, pin);

            
            if (userAuthenticated)
                currentAccountNumber = accountNumber;
            else
                screen.DisplayMessageLine(
                      "Invalid account number or PIN. Please try again.");
        } 

        
        private void PerformTransactions()
        {
            Transaction currentTransaction; 
            bool userExited = false; 

            
            while (!userExited)
            {
                
                int mainMenuSelection = DisplayMainMenu();

                
                switch ((MenuOption)mainMenuSelection)
                {
                    
                    case MenuOption.BALANCE_INQUIRY:
                    case MenuOption.WITHDRAWAL:
                    case MenuOption.DEPOSIT:
                        
                        currentTransaction =
                           CreateTransaction(mainMenuSelection);
                        currentTransaction.Execute(); 
                        break;
                    case MenuOption.EXIT_ATM:
                        screen.DisplayMessageLine("\nExiting the system...");
                        userExited = true; 
                        break;
                    default: 
                        screen.DisplayMessageLine(
                           "\nYou did not enter a valid selection. Try again.");
                        break;
                } 
            } 
        } 

        
        private int DisplayMainMenu()
        {
            screen.DisplayMessageLine("\nMain menu:");
            screen.DisplayMessageLine("1 - View my balance");
            screen.DisplayMessageLine("2 - Withdraw cash");
            screen.DisplayMessageLine("3 - Deposit funds");
            screen.DisplayMessageLine("4 - Exit\n");
            screen.DisplayMessage("Enter a choice: ");
            return keypad.GetInput(); 
        } 

        
        private Transaction CreateTransaction(int type)
        {
            Transaction temp = null; 

            
            switch ((MenuOption)type)
            {
                
                case MenuOption.BALANCE_INQUIRY:
                    temp = new BalanceInquiry(currentAccountNumber,
                       screen, bankDatabase);
                    break;
                case MenuOption.WITHDRAWAL:  
                    temp = new Withdrawal(currentAccountNumber, screen,
                         bankDatabase, keypad, cashDispenser);
                    break;
                case MenuOption.DEPOSIT:  
                    temp = new Deposit(currentAccountNumber, screen,
                         bankDatabase, keypad, depositSlot);
                    break;
            } 

            return temp;
        } 
    } 
}


