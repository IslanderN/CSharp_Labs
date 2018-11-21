using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    interface IRent
    {
        float Days { get; set; }
        string Name { get;  }
        float Hire();
    }
}
