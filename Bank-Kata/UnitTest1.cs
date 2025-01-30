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

            accountService.Deposit(1000); // Première transaction
            accountService.Deposit(2000); // Deuxième transaction
            accountService.Withdraw(500); // Troisième transaction

            //Rediriger la sortie console pour capturer l'état imprimé
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Action
            accountService.PrintStatement();

            //Réinitialiser la sortie console
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });

            //Vérification - Vérifier que la sortie correspond à ce qui est attendu
            string output = consoleOutput.ToString().Trim();
            string expectedHeader = "DATE | AMOUNT | BALANCE";

            // Vérifier que la sortie contient l'en-tête attendu
            Assert.Contains(expectedHeader, output);

            // Récupérer la date d'aujourd'hui pour la comparaison
            string todayDate = DateTime.Now.ToString("dd-MM-yyyy");

            // Vérifier si les transactions sont présentes avec les bons montants et le bon solde
            Assert.Contains($"{todayDate} | 1000 | 1000", output);
            Assert.Contains($"{todayDate} | 2000 | 3000", output);
            Assert.Contains($"{todayDate} | -500 | 2500", output);
        }

        [Fact]
        public void Should_Add_Deposit_Correctly()
        {
            //Arrangement : Créer une instance du service de compte
            AccountService accountService = new Account();

            //Action : Effectuer un dépôt
            accountService.Deposit(1000);

            //Vérification : Récupérer les transactions enregistrées
            var transactions = ((Account)accountService).GetTransactions();

            // Vérifier qu'une seule transaction a été enregistrée
            Assert.Single(transactions);

            // Vérifier que le montant est positif (dépôt)
            Assert.Equal(1000, transactions[0].Amount);

            // Vérifier que la date correspond à la date actuelle (ignorant l'heure)
            Assert.Equal(DateTime.Now.Date, transactions[0].Date.Date);
        }

        [Fact]
        public void Should_Add_Withdrawal_Correctly()
        {
            // Arrangement : Créer une instance du service de compte
            AccountService accountService = new Account();

            //Action : Effectuer un retrait
            accountService.Withdraw(500);

            // Vérification : Récupérer les transactions enregistrées
            var transactions = ((Account)accountService).GetTransactions();

            // Vérifier qu'une seule transaction a été enregistrée
            Assert.Single(transactions);

            // Vérifier que le montant est négatif (retrait)
            Assert.Equal(-500, transactions[0].Amount);

            // Vérifier que la date correspond à la date actuelle (ignorant l'heure)
            Assert.Equal(DateTime.Now.Date, transactions[0].Date);
        }
    }
}