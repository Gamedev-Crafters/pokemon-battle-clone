using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pokemon_Battle_Clone.Runtime.Trainers.Infrastructure.Actions
{
    [RequireComponent(typeof(Button))]
    public class HUDButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image buttonImage;
        [Header("Colors")]
        [SerializeField] private Color unselectedColor = Color.white;
        [SerializeField] private Color selectedColor = Color.black;
        [SerializeField] private Color disabledColor = Color.red;
        
        private List<TextMeshProUGUI> _buttonTexts = new();
        private Button _button;

        public Button Button
        {
            get
            {
                if (_button == null)
                    _button = GetComponent<Button>();
                return _button;
            }
        }
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _buttonTexts = new List<TextMeshProUGUI>(GetComponentsInChildren<TextMeshProUGUI>());
        }

        private void OnDisable()
        {
            Deselect();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (Button.interactable)
                Select();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (Button.interactable)
                Deselect();
        }

        public void SetInteraction(bool interactable)
        {
            Button.interactable = interactable;
            buttonImage.color = interactable ? unselectedColor : disabledColor;
        }

        private void Select()
        {
            buttonImage.color = selectedColor;
            foreach (var text in _buttonTexts)
                text.color = unselectedColor;
        }

        private void Deselect()
        {
            buttonImage.color = unselectedColor;
            foreach (var text in _buttonTexts)
                text.color = selectedColor;
        }
    }
}