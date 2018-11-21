using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class StandartRent : IRent
    {
        public float Days { get; set; }

        public string Name
        {
            get
            {
                return "Стандартна оренда";
            }
        }

        private float price = 10.0f;

        public StandartRent(float days)
        {
            this.Days = days;
        }
        public float Hire()
        {
            return Days * price;
        }
    }
}
