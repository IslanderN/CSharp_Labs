using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Builder
{
    class GameProjectBuilder : ProjectBuilder
    {
        public GameProjectBuilder()
        {
            project = new Project();
        }
        public override void Develope()
        {
            project.Development("Create game", "Game");
        }

        public override void Implement()
        {
            project.Implemention("Advertise the game");
        }

        public override void Support()
        {
            project.Support("Start Close Beta-test");
        }
    }
}
