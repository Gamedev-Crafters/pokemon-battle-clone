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

        public void Init()
        {
            for (int i = 0; i < moveButtons.Count; i++)
            {
                moveButtons[i].index = i;
                moveButtons[i].OnClick += index => OnMoveSelected.Invoke(index);
            }
        }

        public void SetData(MoveSet moveSet)
        {
            for (int i = 0; i < moveButtons.Count; i++)
            {
                if (moveSet.Moves.Count > i)
                {
                    moveButtons[i].gameObject.SetActive(true);
                    moveButtons[i].SetData(moveSet.Moves[i]);
                }
                else
                {
                    moveButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }
}