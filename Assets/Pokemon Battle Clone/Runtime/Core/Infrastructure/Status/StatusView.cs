using System.Collections;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure.Status
{
    public class StatusView : MonoBehaviour
    {
        [Header("Dependencies")]
        [field: SerializeField] public PokemonStatusView Pokemon { get; private set; }
        [field: SerializeField] public TeamStatusView Team { get; private set; }

        [Header("Settings")]
        [SerializeField] private Vector2 showPosition;
        [SerializeField] private Vector2 hidePosition;
        [SerializeField] private float moveDuration = 1f;

        private RectTransform _rectTransform;
        private Coroutine _moveCoroutine;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.anchoredPosition = hidePosition;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                Show();
            if (Input.GetKeyDown(KeyCode.Alpha2))
                Hide();
        }

        public void Show()
        {
            if (_moveCoroutine != null)
                StopCoroutine(_moveCoroutine);
            _moveCoroutine = StartCoroutine(MoveRoutine(hidePosition, showPosition));
        }

        public void Hide()
        {
            if (_moveCoroutine != null)
                StopCoroutine(_moveCoroutine);
            _moveCoroutine = StartCoroutine(MoveRoutine(showPosition, hidePosition));
        }

        private IEnumerator MoveRoutine(Vector2 startPos, Vector2 endPos)
        {
            var elapsed = 0f;
            while (elapsed < moveDuration)
            {
                _rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsed / moveDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            _rectTransform.anchoredPosition = endPos;
        }
    }
}