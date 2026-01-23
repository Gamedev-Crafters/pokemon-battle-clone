using System;
using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pokemon_Battle_Clone.Runtime.Moves.Infrastructure
{
    [RequireComponent(typeof(Button))]
    public class MoveButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI ppText;

        [HideInInspector] public int index;
        
        public event Action<int> OnClick = delegate { };

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => OnClick.Invoke(index));
        }
        
        public void Display(Move move)
        {
            nameText.text = move.Name;
            ppText.text = $"{move.PP.Value} / {move.PP.Max}";
        }
    }
}