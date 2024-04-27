using UnityEngine;
using UnityEngine.UI;
using Window.Common;

namespace Window.MainMenu
{
    public class MainMenuWindowView : CanvasWindowView<MainMenuAdapter>
    {
        [SerializeField] private Button startButton;

        protected override void SetAdapter(MainMenuAdapter adapter)
        {
            base.SetAdapter(adapter);
            startButton.onClick.AddListener(adapter.StartQuiz);
        }
    }
}