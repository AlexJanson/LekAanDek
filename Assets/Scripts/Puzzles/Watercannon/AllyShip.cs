using UnityEngine;
using LekAanDek.Events;

namespace LekAanDek.Puzzles.WaterCannon
{
    public class AllyShip : MonoBehaviour
    {

        [SerializeField]
        private GameObject[] _targets;

        private int _targetsCounter;

        private int _targetsActive;

        [SerializeField]
        private VoidEvent _endGame;

        [SerializeField]
        private AudioSource _fire;

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
                _fire.Stop();
                _endGame.Raise();
            }
        }
    }
}
