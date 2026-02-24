using System;
using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Core.Infrastructure;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using UnityEngine;
using UnityEngine.UI;

namespace Pokemon_Battle_Clone.Runtime.Moves.Infrastructure
{
    public class MoveSetView : MonoBehaviour, ISelectorView
    {
        [SerializeField] private List<MoveButton> moveButtons;
        [SerializeField] private Button backButton;

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

        public void Hide()
        {
            gameObject.SetActive(false);
            backButton.enabled = true;
        }

        public void Show(bool forceSelection)
        {
            gameObject.SetActive(true);
            backButton.enabled = !forceSelection;
        }
    }
}