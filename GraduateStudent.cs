public class GraduateStudent : Student
{
    public string ThesisTitle { get; set; }
    public string Advisor { get; set; }

    public void DisplayGraduateInfo()
    {
        DisplayInfo();

        Console.WriteLine($"Thesis Title: {ThesisTitle}, Advisor: {Advisor}");
    }
}
