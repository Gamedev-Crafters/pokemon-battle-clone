using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using TMPro;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class MoveButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI ppText;

        public void Display(Move move)
        {
            nameText.text = move.Name;
            ppText.text = $"{move.PP.Value} / {move.PP.Max}";
        }
    }
}