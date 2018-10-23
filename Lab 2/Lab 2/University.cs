using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class University : IUniversity
    {
        public void MasterProfession()
        {
            Console.WriteLine("Become a better mathematician");
        }

        public void PrepareToLabs()
        {
            Console.WriteLine("Prepare to lab works");
        }
    }
}
