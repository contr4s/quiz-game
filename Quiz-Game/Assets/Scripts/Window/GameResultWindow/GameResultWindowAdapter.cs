using Window.Common;

namespace Window.GameResultWindow
{
    public class GameResultWindowAdapter : CallbackWindowAdapter, IWindowAdapter<GameResultWindowModel>
    {
        public int TotalQuestions { get; private set; }
        public int CorrectAnswers { get; private set; }
        
        public void SetUp(GameResultWindowModel model)
        {
            base.SetUp(model);
            TotalQuestions = model.TotalQuestions;
            CorrectAnswers = model.CorrectAnswers;
        }
    }
}