using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace Quiz
{
    public class QuizQuestion
    {
        [JsonProperty("answers")]
        private QuizAnswerVariant[] _answerVariants;
        
        private HashSet<string> _cachedAnswers;
        private HashSet<string> CachedAnswers => _cachedAnswers ??= _answerVariants
                                                                    .Where(x => x.IsCorrect)
                                                                    .Select(x => x.Text)
                                                                    .ToHashSet();
        
        [JsonProperty("question")]
        public string Question { get; private set; }
        
        [JsonProperty("background")]
        public string BackgroundPath { get; private set; }
        
        public IReadOnlyList<QuizAnswerVariant> AnswerVariants => _answerVariants;
        
        public Texture2D BackgroundTexture { get; set; }
        
        public bool IsCompleted { get; private set; }
        public bool IsAnsweredCorrect { get; private set; }

        public bool CheckAnswer(IReadOnlyCollection<string> selectedVariants)
        {
            if (IsCompleted)
            {
                Debug.LogWarning($"Question {Question} already completed");
                return IsAnsweredCorrect;
            }
            
            IsCompleted = true;
            IsAnsweredCorrect = CachedAnswers.SetEquals(selectedVariants);
            return IsAnsweredCorrect;
        }
        
        public void Reset()
        {
            IsCompleted = false;
        }
    }
}