using System;
using System.Collections.Generic;
using System.Linq;
using LekAanDek.Variables;
using UnityEngine;

namespace LekAanDek.Puzzles.Marlin
{
    public class EnemyShip : MonoBehaviour
    {
        public List<BoolVariable> targets = new List<BoolVariable>();
        public BoolVariable allTargetsHit;
        
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
            if (AllTargetsHit()) allTargetsHit.Value = true;
        }
        
        private bool AllTargetsHit() => targets.All(target => target.Value);

    }
}
