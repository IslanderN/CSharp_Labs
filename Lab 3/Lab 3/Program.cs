using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            StandartRent standart = new StandartRent(10);

            FineRent fine = new FineRent(20);

            PrivilegedRent privileged = new PrivilegedRent(30);

            Equipment equipment = new Equipment(standart);
            equipment.Hire();
            Console.WriteLine();

            equipment.Rent = fine;
            equipment.Hire();
            Console.WriteLine();

            equipment.Rent = privileged;
            equipment.Hire();
            Console.ReadKey();
        }
    }
}
