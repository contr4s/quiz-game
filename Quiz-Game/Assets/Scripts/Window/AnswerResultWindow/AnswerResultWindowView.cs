using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Window.Common;

namespace Window.AnswerResultWindow
{
    public class AnswerResultWindowView : CanvasWindowView<AnswerResultWindowAdapter>
    {
        [Serializable]
        public struct AnswerResultView
        {
            public string Text;
            public Color Color;
        }
        
        [SerializeField] private Button proceedButton;
        [SerializeField] private TMP_Text text;
        [SerializeField] private Image textBackground;
        [SerializeField] private AnswerResultView correctAnswerView;
        [SerializeField] private AnswerResultView wrongAnswerView;

        protected override void SetAdapter(AnswerResultWindowAdapter adapter)
        {
            base.SetAdapter(adapter);
            proceedButton.onClick.AddListener(Proceed);
        }

        public override void InstantlyShow()
        {
            base.InstantlyShow();
            text.text = Adapter.IsCorrect ? correctAnswerView.Text : wrongAnswerView.Text;
            textBackground.color = Adapter.IsCorrect ? correctAnswerView.Color : wrongAnswerView.Color;
        }
        
        private void Proceed()
        {
            Adapter.Proceed();
            Hide(CancellationToken.None).Forget();
        }
    }
}