using System.Collections.Generic;

namespace Quiz
{
    public class QuizModel
    {
        public IReadOnlyList<QuizQuestion> QuizQuestions { get; }
        public int CurrentQuestion { get; private set; }
        public int CorrectQuestions { get; private set; }
        
        public QuizModel(IReadOnlyList<QuizQuestion> quizQuestions)
        {
            QuizQuestions = quizQuestions;
        }
        
        public void NextQuestion(bool isCorrect)
        {
            if (CurrentQuestion >= QuizQuestions.Count - 1)
            {
                return;
            }
            
            if (isCorrect)
            {
                CorrectQuestions++;
            }

            CurrentQuestion++;
        }
        
        public void Reset()
        {
            CurrentQuestion = 0;
            CorrectQuestions = 0;
        }
    }
}