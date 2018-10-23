using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            School school = new School();

            Console.WriteLine("Studying at school");
            student.Study(school);

            University university = new University();
            Console.WriteLine("\nEnter to Unniversity\n");
            ISchool enterToUnversity = new EnterToUniversityAfterSchool(university);

            Console.WriteLine("Studying at university");
            student.Study(enterToUnversity);

            Console.ReadKey();
        }
    }
}
