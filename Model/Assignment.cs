using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradingSystem.Model
{
    public class Assignment
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        private List<Grade> Grades { get; set; }
        public Assignment(int number, string name)
        {
            this.Number = number;
            this.Name = name;
            this.Grades = new List<Grade>();
        }
        public void AddGrade(Student student, double weight)
        {
            if (Grades.Any(_grade => _grade.StudentRef == student.ID))
            {
                var old_grade = Grades.First(_grade => _grade.StudentRef == student.ID);
                old_grade.Weight = weight;
            }
            else
            {
                Grades.Add(new Grade(student, this, weight));
            }
        }
        public double AverageGrade
        {
            get
            {
                return Grades.Select(grade => grade.Weight).Average();
            }
        }
    }
}
