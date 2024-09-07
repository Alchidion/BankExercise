namespace BankExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account riccardo = new Account("Riccardo");
            riccardo.deposit(1000);
            riccardo.withdraw(500);
            riccardo.deposit(2000);
            riccardo.printStatement();
            riccardo.withdraw(5000);
            riccardo.printStatement();
        }
    }
}