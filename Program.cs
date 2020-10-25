using GradingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradingSystem
{
    class Program
    {
        public static List<Student> Students { get; set; }
        public static List<Assignment> Assignments { get; set; }
        static void Main(string[] args)
        {
            Initialization();
            var IsContinue = true;
            do
            {
                Console.Write("Enter your choise: ");   
                var Key = Console.ReadLine();
                switch (Key)
                {
                    case "1":
                        Console.Write("Enter number assignment: ");
                        if (int.TryParse(Console.ReadLine(), out int numberAssignment))
                            AddGradingToAssignment(numberAssignment);
                        else
                            Console.WriteLine("Invalid Arrgument. Try Again");
                        break;
                    case "2":
                        PrintAverageGradePerAssignment();
                        break;
                    case "3":
                        PrintAverageGradePerStudent();
                        break;
                    case "4":
                        PrintStudentInformationBasedOnAverageGradeInAllAssignments();
                        break;
                    case "5":
                        IsContinue = false;
                        break;
                } 
            } while (IsContinue);
        }
        public static void Initialization()
        {
            Students = new List<Student>
            {
                new Student (2015980033, "Ala' Jaber"),
                new Student (2015980063, "Mohammad Ban Hani"),
                new Student (2015980050, "Saeed Mustafa"),
                new Student (2015980011, "Younis Alomoush"),
            };
            Assignments = new List<Assignment>
            {
                new Assignment(1, "Karel"),
                new Assignment(2, "C# OOP"),
                new Assignment(3, "Dev Ops"),
                new Assignment(4, "Algorithme"),
                new Assignment(5, "Build System"),
            };
        }
        public static void AddGradingToAssignment(int numberAssignment)
        {
            var assignment = Assignments.FirstOrDefault(assignment => assignment.Number == numberAssignment);
            if (assignment == null)
            {
                Console.WriteLine($"Assignment No. {numberAssignment} was not found, try again.");
                return;
            }
            foreach (var student in Students)
            {
                Console.Write($"Enter grade for {student.Name}: ");
                if (double.TryParse(Console.ReadLine(), out double weight))
                {
                    student.AddGrade(assignment, weight);
                    assignment.AddGrade(student, weight);
                }
                else
                {
                    Console.WriteLine($"Invalide Grade... Try again");
                }
            }
        }
        public static void PrintAverageGradePerAssignment()
        {
            foreach (var assignment in Assignments)
            {
                Console.WriteLine($"Average grade for {assignment.Name}: {assignment.AverageGrade}");
            }
        }
        public static void PrintAverageGradePerStudent()
        {
            foreach (var student in Students)
            {
                Console.WriteLine($"Average grade for {student.Name}: {student.AverageGrade}");
            }
        }
        public static void PrintStudentInformationBasedOnAverageGradeInAllAssignments()
        {
            foreach (var student in Students.OrderByDescending(student=> student.AverageGrade))
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
