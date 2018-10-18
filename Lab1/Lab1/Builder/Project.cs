using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Project
    {
        private string development;
        private string implemention;
        private string support;

        private string name;

        public void Development(string dev, string projectName)
        {
            this.development = dev;
            this.name = projectName;
        }

        public void Implemention(string imp)
        {
            this.implemention = imp;
        }

        public void Support(string sup)
        {
            this.support = sup;
        }

        public override string ToString()
        {
            string result = "Project: " + name + "\nDevelopment: " + development + "\nImplemention: " + implemention + "\nSupport: " + support + "\n";
            return result;
        }
    }
}
