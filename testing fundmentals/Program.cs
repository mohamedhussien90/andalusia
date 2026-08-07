using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_fundmentals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount standard = new BankAccount(1000.0, "Alice");

            SavingsAccount savings = new SavingsAccount(2000.0, "Bob", 0.05); 

            savings.ApplyInterest();

            BankAccount[] accounts = new BankAccount[]
            {
                standard,
                savings
            };

            foreach (var account in accounts)
            {
                Console.WriteLine(account.Balance);
                Console.WriteLine(account.Owner);
            }


            Console.WriteLine("--------------------------");

            Shape[] shapes = new Shape[]
                {
                new Circle(5),
                new Rectangle(4, 6),
                new Triangle(4, 5)
                };
            foreach (var shape in shapes) 
            {
                shape.Describe();

                IDrawable drawableShape = shape as IDrawable;

                
                drawableShape?.Draw();
                
                Console.WriteLine();
                Console.WriteLine();

            }
        }



    }

}