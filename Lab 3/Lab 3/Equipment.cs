using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Equipment
    {
        public IRent Rent { get; set; }

        public Equipment(IRent rent)
        {
            Rent = rent;
        }

        public void Hire()
        {
            Console.WriteLine("Орендувати обладнання на {0} днiв, за умови \"{1}\" буде коштувати: {2}", Rent.Days, Rent.Name, Rent.Hire());
        }


    }
}
