using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExercise
{
    public class Account : IAccount
    {
        private int _fund;

        private List<string> _operationsList = new List<string>();

        private string _date = DateTime.Now.ToString("dd/MM/yyyy");

        private string _username;

        public Account(string username)
        {
            _username = username;
            string[] data = File.ReadAllLines(@$"E:\Workspace\BankExercise\BankAccount\{username}.txt");
            Console.WriteLine($"Hello {username}");
            var count = data.ToList().Count;
            _fund = data.ToList().Count == 0 ? 0 : int.Parse(data[0]);
            for(int i  = 1; i < data.Length; i++)
            {
                _operationsList.Add(data[i]);
            }
            
        }
        public void deposit(int amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine("Invalid amount");
                return;
            }
            _fund += amount;
            _operationsList.Add($"{_date} ||  {amount} || {_fund}\n");
            SaveToFile();
            Console.WriteLine("success");
        }

        public void printStatement()
        {
            if(_operationsList is null || _operationsList?.Count <= 0)
            {
                Console.WriteLine("There is no operations for this account");
                return;
            }
            Console.WriteLine("Date       || Amount || Balance");
            foreach (string o in _operationsList)
            {
                Console.Write($"{o}");
            }
        }

        public void withdraw(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount");
                return;
            }
            if(amount > _fund)
            {
                Console.WriteLine("You don't have enough money. Go to work!!!");
                return;
            }
            _fund -= amount;
            _operationsList.Add($"{_date} ||  -{amount} || {_fund}\n");
            SaveToFile();
            Console.WriteLine("success");
        }

        private void SaveToFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(_fund.ToString());
            foreach(string o in _operationsList)
            {
                sb.Append(o);
            }
            File.WriteAllText(@$"E:\Workspace\BankExercise\BankAccount\{_username}.txt", sb.ToString());
        }
    }
}
