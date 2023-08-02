using System;
using System.Collections.Generic;

namespace StudentGradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student Grade Calculator");

            // Prompt the student to enter their name
            Console.Write("Enter your name: ");
            string? studentName = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(studentName))
            {
                Console.WriteLine("Invalid student name. Please try again.");
                return;
            }

            // Prompt the student to enter the number of subjects they have taken
            Console.Write("Enter the number of subjects: ");
            int numberOfSubjects = int.Parse(Console.ReadLine());
            
            


            // Validate the number of subjects
            if (numberOfSubjects <= 0)
            {
                Console.WriteLine("Invalid number of subjects. Please try again.");
                return;
            }

            // Create a dictionary to store subject names and corresponding grades
            Dictionary<string, double> subjectGrades = new Dictionary<string, double>();

            // Loop to input subject names and grades
            for (int i = 0; i < numberOfSubjects; i++)
            {
                Console.Write($"Enter the name of subject {i + 1}: ");
                string? subjectName = Console.ReadLine();

                // Validate subject name
                if (string.IsNullOrWhiteSpace(subjectName))
                {
                    Console.WriteLine("Invalid subject name. Please try again.");
                    i--;
                    continue;
                }

                double grade;
                do
                {
                    Console.Write($"Enter the grade for {subjectName}: ");
                } while (!double.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100);

                subjectGrades.Add(subjectName, grade);
            }

            // Display the student's name and individual subject grades
            Console.WriteLine("\nStudent Name: " + studentName);
            Console.WriteLine("Subject Grades:");
            foreach (var subject in subjectGrades)
            {
                Console.WriteLine($"{subject.Key}: {subject.Value}");
            }

            // Calculate the average grade
            double totalGrade = 0;
            foreach (var grade in subjectGrades.Values)
            {
                totalGrade += grade;
            }
            double averageGrade = totalGrade / subjectGrades.Count;

            // Display the average grade
            Console.WriteLine($"Average Grade: {averageGrade:F2}");
        }
    }
}
