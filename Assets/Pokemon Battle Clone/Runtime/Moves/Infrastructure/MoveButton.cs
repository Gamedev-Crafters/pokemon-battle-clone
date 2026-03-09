using System;
using Pokemon_Battle_Clone.Runtime.Core.Infrastructure.Types;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pokemon_Battle_Clone.Runtime.Moves.Infrastructure
{
    [RequireComponent(typeof(Button))]
    public class MoveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image typeIcon;
        [SerializeField] private Image background;
        [SerializeField] private GameObject border;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI ppText;
        
        [Space(10)]
        [SerializeField] private ElementalTypesConfig elementalTypesConfig;

        [HideInInspector] public int index;
        
        private Button _button;
        
        public event Action<int> OnClick = delegate { };

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => OnClick.Invoke(index));
        }
        
        public void SetData(MoveDTO move)
        {
            nameText.text = move.Name;
            ppText.text = $"{move.CurrentPP} / {move.MaxPP}";

            _button.interactable = move.CurrentPP > 0;
            
            typeIcon.sprite = elementalTypesConfig.GetIcon(move.Type);
            background.color = elementalTypesConfig.GetColor(move.Type);
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            border.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            border.SetActive(false);
        }
    }
}