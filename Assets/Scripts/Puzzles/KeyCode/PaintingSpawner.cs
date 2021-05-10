using LekAanDek.Collections;
using LekAanDek.Variables;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scipt manages the spawning of paintings.
/// </summary>
namespace LekAanDek.KeyCode
{
    public class PaintingSpawner : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Reference to the points of which the paintings will spawn.")]
        private List<Transform> _points;
        [SerializeField]
        [Tooltip("Reference to the painting colors.")]
        private ColorCollection _colors;
        [SerializeField]
        [Tooltip("Reference to the prefab of the painting.")]
        private GameObject _prefab;
        [SerializeField]
        [Tooltip("Reference to the correct input.")]
        private StringVariable _correctInput;
        [SerializeField]
        [Tooltip("Number textures of the paintings.")]
        private List<Sprite> _paintingTextures;

        [Header("- On start only -")]
        [SerializeField]
        [Tooltip("[!] Enabling this will shuffle the list and move the correct numbers to the end, when picked they'll do so as well" +
            "\n\nThis will result in less randomness but also less repetitive numbers." +
            "\n\n-Example-" +
            "\n────┬──────────┬───────" +
            "\nCODE |  GENERATION   |    STATE" +
            "\n────┼──────────┼───────" +
            "\n9338  | 164288833862 | DISABLED" +
            "\n0860  | 493752648792 | ENABLED")]
        bool _lessDoubles;
        [SerializeField]
        [Tooltip("Max index the generation will pick from." +
            "\n\n-Example-" +
            "\nCode: 5867" +
            "\nLessDoubleEnd: 5" +
            "\n\n-Result-\nUsed numbers on 5>>[20193]4{5678}<<Code shifted back after shuffle.")]
        [Range(0, 9)]
        int _lessDoublesEnd = 5;
        [Header("- EXPERIMENTAL -")]
        [SerializeField]
        [Tooltip("[!] THIS IS AN EXPERIMENTAL FEATUE AND MAY CAUSE ISSUES, PLEASE ONLY USE THIS WHEN YOU KNOW WHAT YOU'RE DOING." +
            "\n\nThis will remove the value from the local list and thus making it unable to ever appear again." +
            "\nIt should work fine as long as you have enough values and colors. (Just don't exeed more than 10 paintings ;) )" +
            "\n\nNote: Keep in mind that if the code itself has a double, that it still will have a double in the scene." +
            "\nSo if you consider using this, be sure to toggle the 'No Duplicates' on the generator!")]
        bool _noDoubles = false;
        [SerializeField]
        [Tooltip("[!] THIS IS AN EXPERIMENTAL FEATUE AND MAY CAUSE ISSUES, PLEASE ONLY USE THIS WHEN YOU KNOW WHAT YOU'RE DOING." +
            "\n\nThis uses the point as the prefab, this may be handy when building the scene and see them visually." +
            "\nAfter looking at the results, it should work fine as long as the point has a proper structure that equals to the prefab.")]
        bool _pointIsPrefab = false;
        private List<int> _numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        void Start()
        {
            if (_lessDoubles || _noDoubles)
            {
                PreShuffle(_numbers);
                MoveCorrectOnes();
            }
            GeneratePaintings();
        }

        //Move the ones in the correct code to the last place in the list
        void MoveCorrectOnes()
        {
            for (int i = 0; i < _correctInput.Value.Length; i++)
            {
                int tmp = int.Parse(_correctInput.Value[i].ToString());
                if (_numbers.IndexOf(tmp) != -1) _numbers.RemoveAt(_numbers.IndexOf(tmp));
                if (!_noDoubles) _numbers.Add(tmp);
            }
        }

        //This function spawns the correct paintings first and afterwards follows up with other paintings, it assigns the color, texture, etc.
        void GeneratePaintings()
        {
            int generatedNumber = -1, selectedPoint, tmp = _points.Count;
            for (int i = 0; i < tmp; i++)
            {
                selectedPoint = Random.Range(0, _points.Count);//Pick random spawnpoint
                GameObject obj = _pointIsPrefab ? _points[selectedPoint].gameObject : Instantiate(_prefab, _points[selectedPoint]);
                obj.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = _colors[i];
                if (_correctInput.Value.Length < i + 1) //Check if we passed the spawning of the correct paintings
                {
                        generatedNumber = _lessDoubles ? _numbers[Random.Range(0, !_noDoubles ? _lessDoublesEnd : _numbers.Count)] : _numbers[Random.Range(0, _numbers.Count)];
                        if (_numbers.IndexOf(generatedNumber) != -1) _numbers.RemoveAt(_numbers.IndexOf(generatedNumber));
                        if (!_noDoubles) _numbers.Add(generatedNumber);
                }
                obj.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = _paintingTextures[_correctInput.Value.Length > i ? int.Parse(_correctInput.Value[i].ToString()) : generatedNumber];
                _points.RemoveAt(selectedPoint); //Remove possible spawn point
            }
        }

        void PreShuffle(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                int temp = input[i];
                int randomIndex = Random.Range(i, input.Count);
                input[i] = input[randomIndex];
                input[randomIndex] = temp;
            }
        }
    }
}
