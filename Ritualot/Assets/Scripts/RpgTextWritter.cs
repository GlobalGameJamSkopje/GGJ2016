using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class RpgTextWritter : MonoBehaviour
    {
        private Text _guiText;

        private int _currentPosition = 0;
        private float _delay = 0.1f;
        private string _text = "";
        private string[] _additionalLines;

        private void WriteText(string text)
        {
            _guiText.text = "";
            _currentPosition = 0;
            _text = text;
        }

        public void Awake()
        {
            _guiText = gameObject.GetComponent<Text>();
        }

        public void Start()
        {
            foreach (var line in _additionalLines)
                _text += line;

            while (true)
            {
                if (_currentPosition < _text.Length)
                {
                    _guiText.text += _text[_currentPosition++];
                    StartCoroutine(DelayTextWrite());
                }
            }
        }

        IEnumerator DelayTextWrite()
        {
            yield return new WaitForSeconds(_delay);
        }
    }
}