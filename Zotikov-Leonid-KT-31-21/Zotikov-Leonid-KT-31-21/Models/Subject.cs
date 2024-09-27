namespace Zotikov_Leonid_KT_31_21.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        //связь
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
