using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LekAanDek.Variables;
using LekAanDek.Collections;

namespace LekAanDek.KeyCode
{
    public class PadDisplay : MonoBehaviour
    {
        //Used to fetch the length
        [SerializeField]
        private StringVariable _correctCode, _currentCode;
        [SerializeField]
        private bool _completed;
        [SerializeField]
        private ColorCollection _colors;
        [SerializeField]
        private Text _display;
        [SerializeField]
        private string EmptyPoints = "-  ";
        [SerializeField]
        private Animator _feedback;

        // Start is called before the first frame update
        public void Attempt(bool input)
        {
            if (input)
                CorrectPin();
            else
                WrongPin();
            UpdatePin();
        }

        string AddDashes()
        {
            int tmp1 = Mathf.Abs(_correctCode.Value.Length - _currentCode.Value.Length);
            string tmp2 = "";
            for (int i = 0; i < Mathf.Abs(tmp1 - _correctCode.Value.Length); i++)
            {
                tmp2 = tmp2 + $"{_currentCode.Value[i]} ";
            }
            for (int i = 0; i < tmp1; i++)
            {
                tmp2 = tmp2 + $"<color=#{ColorUtility.ToHtmlStringRGB(_colors[i + _currentCode.Value.Length])}>{EmptyPoints}</color>";
            }
            return tmp2;
        }

        // Update is called once per frame
        public void UpdatePin()
        {
            _display.text = $" {AddDashes()}";
        }

        void WrongPin()
        {
            _feedback.SetTrigger("Wiggle");
            //Flicker red and wiggle
        }

        void CorrectPin()
        {
            _feedback.SetTrigger("Blink");
            //Make display green
        }
    }
}
