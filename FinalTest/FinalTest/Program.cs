using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleDB db = new TriangleDB();
            //db.Connect();
            bool correct = false;
            double square = 0;

            while (!correct)
            {
                Console.WriteLine("Enter square:");

                string str = Console.ReadLine();

                if(!double.TryParse(str, out square))
                {
                    correct = false;
                    Console.WriteLine("Enter isn't correct");

                }
                else
                {
                    correct = true;
                }
            }

            db.FindTriangleSquare(square);

            //db.Test();

            Console.ReadKey();

        }
    }
}
