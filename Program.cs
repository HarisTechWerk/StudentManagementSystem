using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static List<Student> students = new List<Student>();

    static void Main(string[] args)
    {
        LoadStudents();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Student Management System ---");
            Console.WriteLine("1. View Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Save and Exit");
            Console.WriteLine("5. Search Students");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewStudents();
                    break;
                case "2":
                    AddStudent();
                    break;
                case "3":
                    RemoveStudent();
                    break;
                case "4":
                    SaveStudents();
                    Console.WriteLine("Students saved. Goodbye!");
                    return;
                case "5":
                    SearchStudents();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ViewStudents()
    {
        Console.WriteLine("\n--- Student List ---");
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
        }
        else
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }


    static void AddStudent()
    {
        Console.Write("\nEnter Name: ");
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

        Console.WriteLine("Student added successfully! Press any key to return to the menu.");
        Console.ReadKey();
    }

    static void RemoveStudent()
    {
        Console.Write("\nEnter Student ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        var student = students.Find(s => s.Id == id);
        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student removed successfully!");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    static void SaveStudents()
    {
        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("students.json", json);
    }

    static void LoadStudents()
    {
        if (File.Exists("students.json"))
        {
            string json = File.ReadAllText("students.json");
            students = JsonSerializer.Deserialize<List<Student>>(json);
        }
    }

    static void SearchStudents()
    {
        Console.WriteLine("Enter student name or ID to search: ");
        string query = Console.ReadLine();

        var results = students.FindAll(s =>
        s.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
        s.Id.ToString() == query);

        if (results.Count > 0)
        {
            Console.WriteLine("\n---Search Results: ");
            foreach (var student in results)
            {
                Console.WriteLine(student);
            }
        }
        else
        {
            Console.WriteLine("No matching students found.");
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }
}

    