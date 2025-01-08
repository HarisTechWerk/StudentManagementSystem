using StudentManagementSystem;

public class Student : IStudent
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }


    public virtual string GetDetails()
    {
        return $"ID: {Id}, Name: {Name}, Age: {Age}, Grade: {Grade}";
    }

    public override string ToString()
    {
        return GetDetails();
    }
}
