using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Manager
    {
        public Project CreateProject(ProjectBuilder builder)
        {
            builder.Develope();
            builder.Implement();
            builder.Support();

            return builder.GetProject();
        }
    }
}
