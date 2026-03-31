namespace Quiz_med_api
{
    public class Result
    {
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }

}
