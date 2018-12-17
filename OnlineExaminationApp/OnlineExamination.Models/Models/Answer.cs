namespace OnlineExamination.Models.Models
{
    public class Answer
    {
        public long Id { get; set; }
        public string Ans { get; set; }
        public bool CurrectAns { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Questions { get; set; }
    }
}
