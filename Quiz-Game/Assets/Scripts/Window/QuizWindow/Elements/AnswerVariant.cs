using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Util;

namespace Window.QuizWindow.Elements
{
    public class AnswerVariant : UIBehaviour, IResettable
    {
        public event Action<string, bool> OnSelectedStatusChanged;
        
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text text;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color unselectedColor;
        
        public bool IsSelected { get; private set; }

        public string Text
        {
            get => text.text; 
            set => text.text = value;
        }

        protected override void Awake()
        {
            base.Awake();
            button.onClick.AddListener(SwitchState);
        }

        private void SwitchState()
        {
            IsSelected = !IsSelected;
            button.image.color = IsSelected ? selectedColor : unselectedColor;
            OnSelectedStatusChanged?.Invoke(Text, IsSelected);
        }

        public void ResetDefaults()
        {
            IsSelected = false;
            button.image.color = unselectedColor;
        }
    }
}