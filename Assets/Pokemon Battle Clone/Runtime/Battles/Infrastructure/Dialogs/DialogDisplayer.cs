using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Battles.Infrastructure.Dialogs
{
    public class DialogDisplayer : MonoBehaviour, IDialogDisplay
    {
        [SerializeField] private TextMeshProUGUI displayText;
        [SerializeField] private float timeToClear = 2f;
        
        private TaskCompletionSource<bool> _textTCS;
        private bool _textDisplayed;

        private float _textTimer;

        private void Start()
        {
            Clear();
        }

        private void Update()
        {
            if (_textDisplayed)
            {
                _textTimer += Time.deltaTime;
                if (_textTimer >= timeToClear)
                    CompleteText();
            }
        }

        public async Task DisplayAsync(string text)
        {
            _textDisplayed = true;
            displayText.text = text;
            _textTimer = 0f;
            
            _textTCS = new TaskCompletionSource<bool>();
            await _textTCS.Task;
        }

        public void Display(string text)
        {
            displayText.text = text;
        }

        public void Close() => Clear();

        private void CompleteText()
        {
            Clear();
            _textTCS.TrySetResult(true);
        }

        private void Clear()
        {
            _textDisplayed = false;
            displayText.text = "";
        }
    }
}