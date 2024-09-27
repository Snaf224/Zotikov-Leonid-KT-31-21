namespace Zotikov_Leonid_KT_31_21.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName {  get; set; }

        //connect tables
        public int GroupId { get; set; }

        public Group Group {  get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
