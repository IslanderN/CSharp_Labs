using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Student
    {
        public void Study(ISchool school)
        {
            school.MakeHomework();
            school.LearnSubject();
        }

    }
}
