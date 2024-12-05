namespace Example19_11_24.Data
{
    public class ShowData(CollegeContext context)
    {
        Student student2 = new Student
        {
            FirstName = "Jack",
            LastName = "Smith",
            DateOfBirth = new DateTime(2004, 4, 26),
            Email = "jack.smith@student.abcuniversity.com"
        };
    }
}
