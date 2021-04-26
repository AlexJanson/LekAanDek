using UnityEngine;
using UnityEngine.UI;
using LekAanDek.Variables;
using LekAanDek.Collections;

namespace LekAanDek.KeyCode
{
    /// <summary>
    /// This is a script that show the current display input as well as managing colors for the unfilled fields.
    /// </summary>
    public class PadDisplay : MonoBehaviour
    {
        [SerializeField] [Tooltip("The correct code to unlock and the current playerinput.")]
        private StringVariable _correctCode, _currentCode;
        [SerializeField] [Tooltip("A collection of colors which will appear in order at the display. [!]Note that if there are more characters than colors that the text will turn black.")]
        private ColorCollection _colors;
        [SerializeField] [Tooltip("The textobject of the screen.")]
        private Text _display;
        [SerializeField] [Tooltip("The value that fills the empty spots (Spaces are reccomended for matching seperation.)")]
        private string emptyPoints = "-  ";
        [SerializeField] [Tooltip("The animator to give the player a visual feedback.")]
        private Animator _feedback;

        public void Attempt(bool input)
        {
            if (input)
                CorrectPin();
            else
                WrongPin();
            UpdateDisplay();
        }

        //A small function that adds the numbers and colors to the inputfield,
        //[!] This also reverts to black if there aren't enough colours to fill the lenght of the generated code.
        string AddDashes()
        {
            int tmp1 = Mathf.Abs(_correctCode.Value.Length - _currentCode.Value.Length);
            string tmp2 = "";
            for (int i = 0; i < Mathf.Abs(tmp1 - _correctCode.Value.Length); i++)
                tmp2 = tmp2 + $"{_currentCode.Value[i]} ";
            for (int i = 0; i < tmp1; i++)
                tmp2 = tmp2 + $"<color=#{(_colors.List.Count >= _correctCode.Value.Length ? ColorUtility.ToHtmlStringRGB(_colors[i + _currentCode.Value.Length]) : "000000")}>{emptyPoints}</color>";
            return tmp2;
        }

        public void UpdateDisplay() => _display.text = $" {AddDashes()}";

        void WrongPin() => _feedback.SetTrigger("Wiggle");
        //You might want to add a sound here once we start working on that

        void CorrectPin() => _feedback.SetTrigger("Blink");
        //You might want to add a sound here once we start working on that
    }
}
