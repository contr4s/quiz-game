using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Window.Common;

namespace Window.GameResultWindow
{
    public class GameResultWindowView : CanvasWindowView<GameResultWindowAdapter>
    {
        [SerializeField] private Button proceedButton;
        [SerializeField] private TMP_Text text;
        [SerializeField] private string textPrefix;
        
        protected override void SetAdapter(GameResultWindowAdapter adapter)
        {
            base.SetAdapter(adapter);
            proceedButton.onClick.AddListener(Proceed);
        }

        public override void InstantlyShow()
        {
            base.InstantlyShow();
            text.text = $"{textPrefix}: {Adapter.TotalQuestions.ToString()}/{Adapter.CorrectAnswers.ToString()}";
        }
        
        private void Proceed()
        {
            Adapter.Proceed();
        }
    }
}