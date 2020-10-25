using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradingSystem.Model
{
    public class Student
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        private List<Grade> Grades { get; set; }
        public Student(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            Grades = new List<Grade>();
        }
        public void AddGrade(Assignment assignment, double weight)
        {
            if (Grades.Any(_grade => _grade.AssignmentRef == assignment.Number))
            {
                var old_grade = Grades.First(_grade => _grade.AssignmentRef == assignment.Number);
                old_grade.Weight = weight;
            }
            else
            {
                Grades.Add(new Grade(this, assignment, weight));
            }
        }
        public double AverageGrade
        {
            get
            {
                return Grades.Select(grade => grade.Weight).Average();
            }
        }
        public override string ToString()
        {
            return $"{this.Name}: {string.Join(", ", this.Grades.Select(grade=> grade.Weight))}";
        }
    }
}
