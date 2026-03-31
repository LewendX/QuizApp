namespace Quiz_med_api
{
    using QuizApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ApiClient
    {
        HttpClient client = new HttpClient();

        public async Task<QuizQuestion> GetQuestion()
        {
            string url = "https://opentdb.com/api.php?amount=1&category=15&difficulty=hard";
            int tries = 0;
            TimeSpan wait = TimeSpan.FromSeconds(1);

            while (true)
            {
                tries++;
                var res = await client.GetAsync(url);

                if (res.IsSuccessStatusCode)
                {
                    var json = await res.Content.ReadAsStringAsync();
                    var data = JsonDocument.Parse(json).RootElement.GetProperty("results")[0];

                    string q = data.GetProperty("question").GetString();
                    string correct = data.GetProperty("correct_answer").GetString();

                    var answers = data.GetProperty("incorrect_answers")
                        .EnumerateArray()
                        .Select(x => x.GetString())
                        .ToList();

                    answers.Add(correct);

                    var rnd = new Random();
                    answers = answers.OrderBy(x => rnd.Next()).ToList();

                    return new QuizQuestion
                    {
                        Question = WebUtility.HtmlDecode(q),
                        Answers = answers,
                        CorrectAnswer = correct
                    };
                }

                if (res.StatusCode == (HttpStatusCode)429 && tries <= 5)
                {
                    await Task.Delay(wait);
                    wait = TimeSpan.FromSeconds(Math.Min(wait.TotalSeconds * 2, 30));
                    continue;
                }

                var body = await res.Content.ReadAsStringAsync();
                throw new HttpRequestException($"{(int)res.StatusCode} {res.ReasonPhrase} {body}");
            }
        }
    }
}