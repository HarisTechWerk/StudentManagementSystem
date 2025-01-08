public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}, Grade: {Grade}");
    }
}
