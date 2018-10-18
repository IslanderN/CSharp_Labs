using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab1.Builder;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            
            //Create prject Goods Delivery
            GoodsDeliveryProjectBuilder goodsDelivery = new GoodsDeliveryProjectBuilder();

            Project goodsDeliveryProject = manager.CreateProject(goodsDelivery);

            Console.WriteLine(goodsDeliveryProject.ToString());

            //Create project Game
            GameProjectBuilder game = new GameProjectBuilder();

            Project gameProject = manager.CreateProject(game);

            Console.WriteLine(gameProject.ToString());

            Console.ReadKey();
        }
    }
}
