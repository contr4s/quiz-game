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

        public bool IsAnswerCorrect(IReadOnlyCollection<string> selectedVariants)
        {
            return CachedAnswers.SetEquals(selectedVariants);
        }
    }
}