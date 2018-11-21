using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class FineRent : IRent
    {
        public float Days { get; set; }

        public string Name
        {
            get { return "Штрафна оренда"; }
        }

        private float price = 10.0f;

        public FineRent(float days)
        {
            this.Days = days;
        }

        public float Hire()
        {
            return Days * price * 1.15f;
        }
    }
}
