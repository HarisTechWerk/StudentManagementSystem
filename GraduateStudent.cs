public class GraduateStudent : Student
{
    public string ThesisTitle { get; set; }
    public string Advisor { get; set; }

    public override string GetDetails()
    {
        return base.GetDetails() + $", Thesis Title: {ThesisTitle}, Advisor: {Advisor}";
    }
}
