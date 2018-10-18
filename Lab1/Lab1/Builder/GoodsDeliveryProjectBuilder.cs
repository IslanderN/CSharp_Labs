using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Builder
{
    class GoodsDeliveryProjectBuilder : ProjectBuilder
    {
        public GoodsDeliveryProjectBuilder()
        {
            project = new Project();
        }

        public override void Develope()
        {
            project.Development("Develop delivery algorithm", "Goods Delivery");
        }

        public override void Implement()
        {
            project.Implemention("Set the algorithm on drones");
        }

        public override void Support()
        {
            project.Support("Fix bugs");
        }
    }
}
