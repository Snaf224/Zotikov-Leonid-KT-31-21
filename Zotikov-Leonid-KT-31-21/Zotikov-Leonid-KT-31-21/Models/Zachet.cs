namespace Zotikov_Leonid_KT_31_21.Models
{
    public class Zachet
    {
        public int ZachetId { get; set; }

        public string StudentCard { get; set; }

        public string Subject { get; set; }

        public string NameTeacher { get; set; }

        //связь
        public int StudentId { get; set; }

        public Student student { get; set; }   
    }
}
