namespace Quiz_med_api
{
    using System.Collections.Generic;
    public class QuizQuestion
    {
        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public string CorrectAnswer { get; set; }
    }
}