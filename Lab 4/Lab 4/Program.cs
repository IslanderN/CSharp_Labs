using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab_4.CompanyProject;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Project> projects = new List<Project>()
            {
                new Project(){Name = "General relativity"},
                new Project(){Name ="Transistor"},
                new Project(){Name = "Manhattan Project"}
            };

            List<Partisipant> partisipants = new List<Partisipant>()
            {
                new Partisipant() { IdProject = 1, Name = "Albert", Surname="Einstein"  },
                new Partisipant() {IdProject = 2, Name = "Julius Edgar", Surname = "Lilienfeld" },
                new Partisipant() { IdProject = 2, Name ="John", Surname="Bardeen" },
                new Partisipant() { IdProject = 2, Name =  "Walter Houser",Surname = "Brattain"},
                new Partisipant() {IdProject = 2, Name = "William", Surname = "Shockley" },
                new Partisipant() { IdProject = 3, Name = "J. Robert", Surname = "Oppenheimer" },
                new Partisipant() { IdProject = 3, Name = "Otto", Surname = "Hahn" },
                new Partisipant() { IdProject = 3, Name = "Fritz", Surname = "Strassmann" },
                new Partisipant() { IdProject = 3, Name = "Lise",Surname = "Meitner"},
                new Partisipant() { IdProject = 3, Name = "Otto", Surname="Frisch" },
                new Partisipant() { IdProject = 3, Name ="Rudolf", Surname="Peierls" },
                new Partisipant() { IdProject = 3, Name ="Mark",Surname = "Oliphant" }
            };
            List<TimeWorkon> projectTimes = new List<TimeWorkon>()
            {
                new TimeWorkon() { IdProject = 1, Begin = new DateTime(1909, 1, 1), End = new DateTime(1956, 1, 1) },
                new TimeWorkon() { IdProject = 2, Begin = new DateTime(1909,1,1), End  = new DateTime(1956,1,1 ) },
                new TimeWorkon() { IdProject = 3, Begin = new DateTime(1942,1,1), End = new DateTime(1946,1,1) }
            };

            List<CompanyProject.Task> tasks = new List<CompanyProject.Task>()
            {
                new CompanyProject.Task() { IdProject = 1, Name = "Thought Experiment", Costs = 0},
                new CompanyProject.Task() { IdProject = 1, Name = "Eight-year search for a relativistic theory of gravity",Costs = 1000 },
                new CompanyProject.Task() { IdProject = 2, Name = "Discover the crystal diode oscillator", Costs = 10000 },
                new CompanyProject.Task() { IdProject = 2, Name = "Perform experiments and observed on two gold point contacts", Costs = 3400 },
                new CompanyProject.Task() { IdProject = 2, Name="Invente point-contact transistor", Costs = 1500 },
                new CompanyProject.Task() { IdProject = 2, Name = "Develop surface-barrier germanium transistor", Costs = 2650 },
                new CompanyProject.Task() { IdProject = 3, Name = "Design bomb concepts", Costs = 195000 },
                new CompanyProject.Task() { IdProject = 3, Name = "Isotope separation", Costs = 400000},
                new CompanyProject.Task() { IdProject = 3, Name = "Electromagnetic separation", Costs = 850000 },
                new CompanyProject.Task() { IdProject = 3, Name = "Gaseous diffusion", Costs = 723000},
                new CompanyProject.Task() { IdProject = 3, Name = "Thermal diffusion", Costs = 505000 },
                new CompanyProject.Task() { IdProject = 3, Name="Aggregate U-235 production",Costs = 1100000 },
                new CompanyProject.Task() { IdProject = 3, Name="Separation process", Costs = 760000 }
            };

            //All projects
            Console.WriteLine("All Projects:");

            ////
            var q1 = from p in projects
                     orderby p.ID
                     select new { id = p.ID, name = p.Name };
            ////
            foreach (var p in q1)
            {
                Console.WriteLine($"{p.id}. {p.name}");
            }
            ////

            Console.WriteLine(new string('-', 100) + Environment.NewLine);

            //All Partitsipans
            Console.WriteLine("All Partisipans");

            ////
            var q2 = from p in partisipants
                     orderby p.IdProject, p.Name
                     select new { id = p.IdProject, name = p.Name, surname = p.Surname };
            ////
            foreach(var p in q2)
            {
                Console.WriteLine($"{p.id}. {p.name} {p.surname}");
            }
            ////

            Console.WriteLine(new string('-', 100) + Environment.NewLine);

            //Join
            Console.WriteLine("Join. Project and participations");

            ////
            var q3 = from p in projects
                     join m in partisipants on p.ID equals m.IdProject into temp
                     orderby p.ID
                     select new { id = p.ID, project = p.Name, participations = temp };
            ////
            foreach(var p in q3)
            {
                Console.WriteLine($"{p.id}. {p.project}");
                foreach(var m in p.participations)
                {
                    Console.WriteLine($"    - {m.Name} {m.Surname}");
                }
            }
            ////

            Console.WriteLine(new string('-', 100) + Environment.NewLine);

            //All Tasks
            Console.WriteLine("All Tasks");

            foreach(var t in tasks)
            {
                Console.WriteLine($"{t.IdProject}. {t.Name} = {t.Costs}");
            }

            Console.WriteLine(new string('-', 100) + Environment.NewLine);

            //Select task from All tasks
            Console.WriteLine("Select task from all tasks, where cost more than 2000\n");
            

            ////
            var q4 = from t in tasks
                     where t.Costs > 2000
                     select t;
            ////
            foreach(var t in q4)
            {
                Console.WriteLine($"{t.IdProject}. {t.Name} = {t.Costs}");
            }
            ////


            Console.WriteLine(new string('-', 100) + Environment.NewLine);

            ////Group
            Console.WriteLine("Group all tasks from projects and Sum costs\n");

            ////
            var q5 = from t in tasks
                     join p in projects on t.IdProject equals p.ID
                     group t by p.Name into g
                     select new { key = g.Key, value = g, sum = g.Sum(c=>c.Costs) };
            ////
            foreach(var t in q5)
            {
                Console.WriteLine("{0} : {1:C}", t.key, t.sum);
                foreach(var g in t.value)
                {
                    Console.WriteLine($"    -{g.Name}");
                }
            }
            ////

            Console.WriteLine(new string('-', 100) + Environment.NewLine);

            ////Concat
            Console.WriteLine("Select Partisipant whos name or surame start with \'O\'\n");
            

            var q6 = from p in partisipants
                     where p.Name.StartsWith("O")
                     select p;
            var q7 = from p in partisipants
                     where p.Surname.StartsWith("O")
                     select p;
            
            ////
            foreach(var p in q6.Concat(q7))
            {
                Console.WriteLine($"{p.Name} - {p.Surname}");
            }
            ////

            Console.ReadKey();


        }
    }
}
