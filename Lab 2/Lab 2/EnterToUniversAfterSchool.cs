using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class EnterToUniversityAfterSchool :ISchool
    {
        University university;
        public EnterToUniversityAfterSchool(University uni)
        {
            university = uni;
        }

        public void LearnSubject()
        {
            university.PrepareToLabs();
        }

        public void MakeHomework()
        {
            university.MasterProfession();
        }
    }
}

