using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.CompanyProject
{
    class Project
    {
        private static int id = 0;
        public int ID { get; private set; }

        public string Name { get; set; }

        //public List<Partisipant> Partisipants { get; set; }
        //public List<Task> Tasks { get; set; }
        //public TimeWorkon ProjectTime { get; set; }

        public Project()
        {
            ID = ++id;
        }
    }
}
