using Window.Common;

namespace Window.AnswerResultWindow
{
    public class AnswerResultWindowAdapter : CallbackWindowAdapter, IWindowAdapter<AnswerResultWindowModel>
    {
        public bool IsCorrect { get; private set; }
        
        public void SetUp(AnswerResultWindowModel model)
        {
            base.SetUp(model);
            IsCorrect = model.IsCorrect;
        }
    }
}