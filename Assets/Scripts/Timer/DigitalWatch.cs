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
    public class DigitalWatch : BaseClock
    {
        [Tooltip("Whether the time dots should blink or not.")]
        [SerializeField]
        private bool _blink;
        private bool _alreadyBlinking;

        [Tooltip("Reference to the timer's text.")]
        [SerializeField]
        private TextMesh _text;
        [Tooltip("The material of the font.")]
        [SerializeField]
        private Material _watchMaterial;
        [Tooltip("Pick colors for different states.")]
        [SerializeField]
        private Color _alarmColor, _timeOverColor, _defaultColor;
        
        [Tooltip("Show 'TI:ME' instead of '00:00'.")]
        [SerializeField]
        private bool _enableTimeText;
        [Tooltip("The text that shows up.")]
        [SerializeField]
        private string _timeText = "TI:JD";

        protected override void Update()
        {
            if (!outOfTime)
                BlinkHandler();
            base.Update();
        }

        private void Start()
        {
            _watchMaterial.color = _defaultColor;
        }

        protected override void DisplayTime()
        {
            _text.text = CalculateTime();
        }

        //Start blinking when the timer starts
        private void StartBlinking()
        {
            _blink = true;
        }

        protected override void RunningOut()
        {
            _watchMaterial.color = _alarmColor;
            //Maybe add looping alarm beep?
            base.RunningOut();
        }

        protected override void OutOfTime()
        {
            _watchMaterial.color = _timeOverColor;
            if (_enableTimeText)
                _text.text = _timeText;
        }

        //Blinking
        private void Blinker()
        {
            StartCoroutine(Blink());
        }
        IEnumerator Blink()
        {
            dots = " ";
            yield return new WaitForSeconds(1f);
            dots = ":";
        }
        private void BlinkHandler()
        {
            if (!_blink && _alreadyBlinking)
            {
                CancelInvoke();
                _alreadyBlinking = false;
            }
            if (_blink && !_alreadyBlinking)
            {
                InvokeRepeating("Blinker", 0.0f, 2f);
                _alreadyBlinking = true;
            }
        }
    }
}
