using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class RpgTextWritter : MonoBehaviour
    {
        public string[] AdditionalLines;

        private Text _guiText;
        private int _currentPosition = 0;
        private float _delay = 0.06f; //~15 chars per second
        private string _text = "";
        
        public void Awake()
        {
            _guiText = gameObject.GetComponent<Text>();
        }

        public IEnumerator Start()
        {
            foreach (var line in AdditionalLines)
                _text += line + "\n";

            while (true)
            {                
                if (_currentPosition < _text.Length)
                   _guiText.text += _text[_currentPosition++];

                yield return new WaitForSeconds(_delay);
            }
        }

        public void InstantGuiText()
        {
            _guiText.text = "";
            _text = "";

            foreach (var line in AdditionalLines)
                _text += line + "\n";

            _guiText.text = _text;
        }
    }
}