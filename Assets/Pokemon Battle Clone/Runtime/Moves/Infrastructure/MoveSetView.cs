using System;
using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Moves.Infrastructure
{
    public class MoveSetView : MonoBehaviour
    {
        [SerializeField] private List<MoveButton> moveButtons;

        public event Action<int> OnMoveSelected = delegate { }; 
        
        private void Awake()
        {
            for (int i = 0; i < moveButtons.Count; i++)
            {
                moveButtons[i].index = i;
                moveButtons[i].OnClick += index => OnMoveSelected.Invoke(index);
            }
        }

        public void Display(MoveSet moveSet)
        {
            for (int i = 0; i < moveButtons.Count; i++)
            {
                if (moveSet.Moves.Count > i)
                {
                    moveButtons[i].gameObject.SetActive(true);
                    moveButtons[i].Display(moveSet.Moves[i]);
                }
                else
                {
                    moveButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }
}