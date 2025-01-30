using Bank_kata.Abstraction;
using Moq;
using System.Reflection;

namespace Bank_Kata
{
    public class UnitTest1
    {
        [Fact]
        public void Should_Print_Correct_Statement()
        {
            //Arrangement
            AccountService accountService = new Account();

            accountService.Deposit(1000); // Premi�re transaction
            accountService.Deposit(2000); // Deuxi�me transaction
            accountService.Withdraw(500); // Troisi�me transaction

            //Rediriger la sortie console pour capturer l'�tat imprim�
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Action
            accountService.PrintStatement();

            //R�initialiser la sortie console
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });

            //V�rification - V�rifier que la sortie correspond � ce qui est attendu
            string output = consoleOutput.ToString().Trim();
            string expectedHeader = "DATE | AMOUNT | BALANCE";

            // V�rifier que la sortie contient l'en-t�te attendu
            Assert.Contains(expectedHeader, output);

            // R�cup�rer la date d'aujourd'hui pour la comparaison
            string todayDate = DateTime.Now.ToString("dd-MM-yyyy");

            // V�rifier si les transactions sont pr�sentes avec les bons montants et le bon solde
            Assert.Contains($"{todayDate} | 1000 | 1000", output);
            Assert.Contains($"{todayDate} | 2000 | 3000", output);
            Assert.Contains($"{todayDate} | -500 | 2500", output);
        }

        [Fact]
        public void Should_Add_Deposit_Correctly()
        {
            //Arrangement : Cr�er une instance du service de compte
            AccountService accountService = new Account();

            //Action : Effectuer un d�p�t
            accountService.Deposit(1000);

            //V�rification : R�cup�rer les transactions enregistr�es
            var transactions = ((Account)accountService).GetTransactions();

            // V�rifier qu'une seule transaction a �t� enregistr�e
            Assert.Single(transactions);

            // V�rifier que le montant est positif (d�p�t)
            Assert.Equal(1000, transactions[0].Amount);

            // V�rifier que la date correspond � la date actuelle (ignorant l'heure)
            Assert.Equal(DateTime.Now.Date, transactions[0].Date.Date);
        }

        [Fact]
        public void Should_Add_Withdrawal_Correctly()
        {
            // Arrangement : Cr�er une instance du service de compte
            AccountService accountService = new Account();

            //Action : Effectuer un retrait
            accountService.Withdraw(500);

            // V�rification : R�cup�rer les transactions enregistr�es
            var transactions = ((Account)accountService).GetTransactions();

            // V�rifier qu'une seule transaction a �t� enregistr�e
            Assert.Single(transactions);

            // V�rifier que le montant est n�gatif (retrait)
            Assert.Equal(-500, transactions[0].Amount);

            // V�rifier que la date correspond � la date actuelle (ignorant l'heure)
            Assert.Equal(DateTime.Now.Date, transactions[0].Date);
        }
    }
}