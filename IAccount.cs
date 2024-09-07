using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExercise
{
    public interface IAccount
    {
        void deposit(int amount);
        void withdraw(int amount);
        void printStatement();
    }
}
