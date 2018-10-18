using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    abstract class ProjectBuilder
    {
        protected Project project;
        public abstract void Develope();
        public abstract void Implement();
        public abstract void Support();

        public virtual Project GetProject()
        {
            return project;
        }
    }
}
