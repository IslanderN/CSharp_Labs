using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class PrivilegedRent : IRent
    {
        public float Days { get; set; }

        public string Name
        {
            get
            {
                return "Пiльгова оренда";
            }
        }

        private float price = 10.0f;

        public PrivilegedRent(float days)
        {
            this.Days = days;
        }

        public float Hire()
        {
            return price * Days * 0.8f;
        }
    }
}
