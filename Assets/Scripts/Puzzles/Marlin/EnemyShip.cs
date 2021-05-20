using System.Collections.Generic;
using System.Linq;
using LekAanDek.Variables;
using LekAanDek.Events;
using UnityEngine;

namespace LekAanDek.Puzzles.Marlin
{
    public class EnemyShip : MonoBehaviour
    {
        public List<BoolVariable> targets = new List<BoolVariable>();
        public BoolVariable allTargetsHit;
        public BoolEvent finishedPuzzle;
        bool _unlocked = false;
        private void Start()
        {
            allTargetsHit.Value = false;
            foreach (var target in targets)
            {
                target.Value = false;
            }
        }

        private void Update()
        {
            if (AllTargetsHit) allTargetsHit.Value = true;
            if (!_unlocked && allTargetsHit.Value) { 
                finishedPuzzle.Raise(true);
                _unlocked = true;
            }
        }

        private bool AllTargetsHit => targets.All(target => target.Value);

    }
}
