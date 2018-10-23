using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class School : ISchool
    {
        public void LearnSubject()
        {
            Console.WriteLine("Learn math.");
        }

        public void MakeHomework()
        {
            Console.WriteLine("Solve math problems");
        }
    }
}
    