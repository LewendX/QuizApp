using QuizApp.Integration;
using QuizApp.Models;
using System.Net;
using System.Net.Http.Json;

namespace QuizApp;

public class QuizApiClient(HttpClient httpClient) : IDisposable
{

    public static QuizApiClient Create()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://opentdb.com/"),
            Timeout = TimeSpan.FromSeconds(30)
        };

        return new QuizApiClient(httpClient);
    }

    public void Dispose() => httpClient.Dispose();

    public async Task<List<QuizQuestion>> GetQuizQuestionsAsync()
    {
        var url = "api.php?amount=5&difficulty=easy&type=multiple";

        var response = await httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var quizResult = await response.Content.ReadFromJsonAsync<OpenTriviaQuizResponse>();

        if (quizResult is null || quizResult.ResponseCode != 0)
        {
            throw new InvalidOperationException("Failed to fetch quiz questions from the API.");
        }

        var result = new List<QuizQuestion>();

        foreach (var item in quizResult.Results)
        {
            result.Add(new QuizQuestion
            (
                WebUtility.HtmlDecode(item.Category),
                WebUtility.HtmlDecode(item.Type),
                WebUtility.HtmlDecode(item.Difficulty),
                WebUtility.HtmlDecode(item.Question),
                WebUtility.HtmlDecode(item.CorrectAnswer),
                [.. item.IncorrectAnswers.Select(o => WebUtility.HtmlDecode(o))]
            ));
        }

        return result;
    }
}
