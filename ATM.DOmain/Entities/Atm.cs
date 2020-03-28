using ATM.Infra;
using static ATM.Domain.Entities.BalanceInquiry;

namespace ATM.Domain.Entities
{
    public class Atm
    {
        private bool userAuthenticated; 
        private int currentAccountNumber; 
        private Screen screen = new Screen(); 
        private Keypad keypad = new Keypad(); 
        private CashDispenser cashDispenser = new CashDispenser(); 
        private DepositSlot depositSlot = new DepositSlot(); 
        private BankDatabase bankDatabase = new BankDatabase();

        public Atm(bool userAuthenticated, int currentAccountNumber, Screen screen,Keypad keypad, CashDispenser cashDispenser, DepositSlot depositSlot, BankDatabase bankDatabase)
        {
            this.userAuthenticated = userAuthenticated;
            this.currentAccountNumber = currentAccountNumber;
            this.screen = screen;
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
                    
                    screen.DisplayMessageLine("\nSeja bem vindx!");
                    AuthenticateUser(); 
                }

                PerformTransactions(); 
                userAuthenticated = false; 
                currentAccountNumber = 0; 
                screen.DisplayMessageLine("\nObrigada pela preferência! Até mais! :)");
            } 
        } 

        
        private void AuthenticateUser()
        {
            
            screen.DisplayMessage("\nPor favor, digite o número da conta: ");
            int accountNumber = keypad.GetInput();


            screen.DisplayMessage("\nDigite o PIN: ");
            int pin = keypad.GetInput();


            userAuthenticated =
               bankDatabase.AuthenticateUser(accountNumber, pin);

            
            if (userAuthenticated)
                currentAccountNumber = accountNumber;
            else
                screen.DisplayMessageLine(
                      "Número da conta ou PIN inválido. Tente novamente.");
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
                        decimal totalAmount;
                        totalAmount = bankDatabase.GetTotalBalance(currentAccountNumber);
                        screen.DisplayMessageLine("\nConta corrente: " + currentAccountNumber + "\nValor total da conta: " + totalAmount);

                        break;

                    case MenuOption.WITHDRAWAL:
                        int withdrawal = WithdrawalMenu();

                        if (withdrawal == 6)
                        {
                            screen.DisplayMessageLine("Transação cancelada");
                            break;
                        }
                        else
                        {
                            bankDatabase.Debit(currentAccountNumber, withdrawal);
                            screen.DisplayMessageLine("\nSaque realizado com sucesso!");
                        }

                        break;
                    case MenuOption.DEPOSIT:
                        int depositValue = DepositMenu();


                        if (depositValue == 0)
                        {
                            screen.DisplayMessageLine("Transação cancelada");
                            break;
                        }
                        else
                        {
                            bankDatabase.Credit(currentAccountNumber, depositValue);
                            screen.DisplayMessageLine("\nQuantia depositada com sucesso!");
                        }
                        break;
                        
                        currentTransaction =
                           CreateTransaction(mainMenuSelection);
                        //currentTransaction.Execute(); 
                        break;
                    case MenuOption.EXIT_ATM:
                        screen.DisplayMessageLine("\nSaindo do sistema...");
                        userExited = true; 
                        break;
                    default: 
                        screen.DisplayMessageLine(
                           "\nVocê não digitou uma opção válida. Tente novamente.");
                        break;
                } 
            } 
        } 

        
        //private void BalanceInquiry()
        //{ 
        //    Transaction transaction = new BalanceInquiry(currentAccountNumber, amount);
        //    transaction.Execute();
        //}

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

        private int WithdrawalMenu()
        {
            screen.DisplayMessageLine("\nMenu de Saque");
            screen.DisplayMessageLine("1 - $20     4 - $100");
            screen.DisplayMessageLine("2 - $40     5 - $200");
            screen.DisplayMessageLine("3 - $60     6 - Cancelar transação");
            screen.DisplayMessage("Escolha uma quantia para o saque: ");
            return keypad.GetInput();
        }

        private int DepositMenu()
        {
            screen.DisplayMessageLine("\nDeposito");
            screen.DisplayMessageLine("0 - Digite zero para sair.");
            screen.DisplayMessage("Digite a quantia que deseja depositar: ");
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


