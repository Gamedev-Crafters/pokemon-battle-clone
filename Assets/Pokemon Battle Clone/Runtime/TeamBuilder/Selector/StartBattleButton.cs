using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pokemon_Battle_Clone.Runtime.TeamBuilder.Selector
{
    public class StartBattleButton : MonoBehaviour
    {
        [SerializeField] private string battleScene;

        public void StartBattle()
        {
            SceneManager.LoadScene(battleScene);
        }
    }
}