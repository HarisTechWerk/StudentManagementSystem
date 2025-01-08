using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
        
        students.Add(new Student { Id = 1, Name = "Haris", Age = 21, Grade = "A" });
        students.Add(new Student { Id = 2, Name = "Sarah", Age = 22, Grade = "B" });

        // Display all students
        Console.WriteLine("Student List:");
        foreach (var student in students)
        {
            student.DisplayInfo();        }

        
        Console.WriteLine("\nAdd a new student:");
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Grade: ");
        string grade = Console.ReadLine();

        students.Add(new Student { Id = students.Count + 1, Name = name, Age = age, Grade = grade });

        Console.WriteLine("\nUpdated Student List:");
        foreach (var student in students)
        {
            student.DisplayInfo();
        }
    }
}
