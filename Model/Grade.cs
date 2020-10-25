using System;
using System.Collections.Generic;
using System.Text;

namespace GradingSystem.Model
{
    public class Grade
    {
        public int? StudentRef => Student?.ID;
        public Student Student { get; private set; }
        public int? AssignmentRef => Assignment?.Number;
        public Assignment Assignment { get; private set; }
        public double Weight { get; set; }

        public Grade(Student student, Assignment assignment, double weight)
        {
            Student = student;
            Assignment = assignment;
            Weight = weight;
        }
    }
}
