using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = LoadStudents();

        while (true)
        {
            Console.WriteLine("\n--- Student Management System ---");
            Console.WriteLine("1. View Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Add Graduate Student");
            Console.WriteLine("4. Save and Exit");
            Console.Write("Choose an option: ");
            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice, please try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    ViewStudents(students);
                    break;

                case 2:
                    AddStudent(students);
                    break;

                case 3:
                    AddGraduateStudent(students);
                    break;

                case 4:
                    SaveStudents(students);
                    Console.WriteLine("Students saved successfully. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void ViewStudents(List<Student> students)
    {
        Console.WriteLine("\n--- Student List ---");
        foreach (var student in students)
        {
            if (student is GraduateStudent graduateStudent)
            {
                graduateStudent.DisplayGraduateInfo();
            }
            else
            {
                student.DisplayInfo();
            }
        }
    }

    static void AddStudent(List<Student> students)
    {
        Console.WriteLine("\n--- Add New Student ---");
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Grade: ");
        string grade = Console.ReadLine();

        students.Add(new Student
        {
            Id = students.Count + 1,
            Name = name,
            Age = age,
            Grade = grade
        });

        Console.WriteLine("Student added successfully!");
    }

    static void AddGraduateStudent(List<Student> students)
    {
        Console.WriteLine("\n--- Add New Graduate Student ---");
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Grade: ");
        string grade = Console.ReadLine();
        Console.Write("Enter Thesis Title: ");
        string thesisTitle = Console.ReadLine();
        Console.Write("Enter Advisor: ");
        string advisor = Console.ReadLine();

        students.Add(new GraduateStudent
        {
            Id = students.Count + 1,
            Name = name,
            Age = age,
            Grade = grade,
            ThesisTitle = thesisTitle,
            Advisor = advisor
        });

        Console.WriteLine("Graduate student added successfully!");
    }

    static void SaveStudents(List<Student> students)
    {
        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("students.json", json);
    }

    static List<Student> LoadStudents()
    {
        if (File.Exists("students.json"))
        {
            string json = File.ReadAllText("students.json");
            return JsonSerializer.Deserialize<List<Student>>(json);
        }
        return new List<Student>();
    }
}
