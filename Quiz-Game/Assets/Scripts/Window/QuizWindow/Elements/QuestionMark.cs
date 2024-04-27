using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Util;

namespace Window.QuizWindow.Elements
{
    public class QuestionMark : UIBehaviour, IResettable
    {
        [SerializeField] private TMP_Text questionNumberText;
        [SerializeField] private Image background;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color correctColor;
        [SerializeField] private Color incorrectColor;
        
        public void SetQuestionNumber(int questionNumber)
        {
            questionNumberText.text = questionNumber.ToString();
        }
        
        public void SetSelected()
        {
            background.color = selectedColor;
        }
        
        public void SetFinished(bool correct)
        {
            background.color = correct ? correctColor : incorrectColor;
        }

        public void ResetDefaults()
        {
            background.color = defaultColor;
        }
    }
}