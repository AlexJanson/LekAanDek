using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Variables;

namespace LekAanDek.Puzzles.WaterCannon
{
    public class AllyShip : MonoBehaviour
    {

        [SerializeField]
        private GameObject[] _targets;

        private int _targetsCounter;

        private int _targetsActive;

        // Start is called before the first frame update
        void Start()
        {
            _targetsActive = _targets.Length;
        }

        // Update is called once per frame
        void Update()
        {
            CountingTargets();
        }

        private void CountingTargets()
        {
            if (_targets[_targetsCounter] == null)
            {
                _targetsActive -= 1;
                _targetsCounter++;
            }

            if (_targetsActive == 0)
            {
                //Game end
            }
        }
    }
}
