using Newtonsoft.Json;

namespace Quiz
{
    public class QuizAnswerVariant
    {
        [JsonProperty("text")]
        public string Text { get; private set; }
        
        [JsonProperty("correct")]
        public bool IsCorrect { get; private set; }
    }
}