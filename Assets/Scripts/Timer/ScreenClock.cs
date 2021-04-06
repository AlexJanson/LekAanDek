using System.Collections;
using UnityEngine;

namespace LekAanDek.Timer
{
    /// <summary>
    /// This script is for the watch that builds upon the base
    /// 
    /// The blinking is used made by using InvokeRepeating.
    /// Source: https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
    /// </summary>
    public class ScreenClock : BaseClock
    {
        [Tooltip("Whether the time dots should blink or not.")]
        [SerializeField]
        private bool _blink;

        [Tooltip("Reference to the timer's text.")]
        [SerializeField]
        private TextMesh _text;
        [Tooltip("The material of the font.")]
        [SerializeField]
        private Material _textMaterial;
        [Tooltip("Pick colors for different states.")]
        [SerializeField]
        private Color _alarmColor, _defaultColor;

        [Tooltip("Disable texture the display.")]
        [SerializeField]
        private bool _removeDisplay = true;
        [Tooltip("The display texture.")]
        [SerializeField]
        private GameObject _display;

        protected override void Update()
        {
            base.Update();
        }

        private void Start()
        {
            InvokeRepeating("Blinker", 0.0f, 2f);
            _textMaterial.color = _defaultColor;
        }

        protected override void DisplayTime()
        {
            _text.text = CalculateTime();
        }

        protected override void RunningOut()
        {
            _textMaterial.color = _alarmColor;
            if (_removeDisplay)
                _display.SetActive(false);
            base.RunningOut();
        }

        public override void EventOutOfTime()
        {
            if (time >= 0)
                _textMaterial.color = _defaultColor;
            outOfTime = true;
        }

        private void Blinker()
        {
            if (_removeDisplay)
                _display.SetActive(false);
            _textMaterial.color = _alarmColor;
            StartCoroutine(BlinkText());
        }
        IEnumerator BlinkText()
        {
            if (outOfTime)
            {
                _text.text = "00:00:00";
                yield return new WaitForSeconds(1f);
                _text.text = "  :  :  ";
            }
            else if (_blink)
            {
                dots = " ";
                yield return new WaitForSeconds(1f);
                dots = ":";
            }
        }
    }
}

