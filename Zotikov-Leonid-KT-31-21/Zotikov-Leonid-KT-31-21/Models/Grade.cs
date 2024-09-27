namespace Zotikov_Leonid_KT_31_21.Models
{
    public class Grade
    {
        public int GradeId { get; set; }   

        public string Subject { get; set; }

        public int Score { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
