using UnityEngine;
using LekAanDek.Collections;
using LekAanDek.Variables;
using System.Collections.Generic;

/// <summary>
/// This scipt generates the code for the keycode puzzle.
/// </summary>
namespace LekAanDek.KeyCode
{
    public class CodeGenerator : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The range of which the code should generate between.\n" +
            "[!] In 'No Duplicate' mode the digits of Y are being used to determine how many to use.")]
        private Vector2Int _generationRange;
        [SerializeField]
        [Tooltip("Reference to the color collection SO")]
        private ColorCollection _colors;
        [SerializeField]
        [Tooltip("Reference to SO code.")]
        private StringVariable _code;

        [Header("- EXPERIMENTAL -")]
        [SerializeField]
        [Tooltip("Wether a duplicate number is allowed to appear." +
            "\n\n[!] This does not look at the max possible value, but at how many digits possible!")]
        private bool _noDoubles;

        private void Awake()
        {
            _colors = shuffle(_colors);
            _code.Value = generateCode(_noDoubles ? _generationRange.y.ToString().Length : _generationRange.x, _generationRange.y);
        }

        //Generates random code by picking options that are available
        private string generateCode(int digits)
        {
            string result = "";
            List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for(int i = 0; i < digits; i++)
            {
                int selectedNum = Random.Range(0, numbers.Count);
                result += numbers[selectedNum];
                numbers.Remove(selectedNum);
            }
            return result;
        }

        //Picks a random value between two variables, adds zeros where it needs to.
        private string generateCode(int min, int max)
        {
            int randomIndex = Random.Range(min, max);
            return Mathf.Abs(randomIndex).ToString().PadLeft(max.ToString().Length, '0');
        }

        //This function, as the name suggests; shuffles the colors in it's collection
        private ColorCollection shuffle(ColorCollection input)
        {
            ColorCollection shuffledCollection = input;
            for (int i = 0; i < shuffledCollection.Count; i++)
            {
                Color tmp = shuffledCollection[i];
                int randomIndex = Random.Range(i, shuffledCollection.Count);
                shuffledCollection[i] = shuffledCollection[randomIndex];
                shuffledCollection[randomIndex] = tmp;
            }
            return shuffledCollection;
        }
    }
}
