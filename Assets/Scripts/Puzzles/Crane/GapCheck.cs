using LekAanDek.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.Puzzles.Crane
{
    public class GapCheck : MonoBehaviour
    {
        [SerializeField]
        private BoolEvent _cranePuzzleCompleted;

        private bool _triggered = false;

        private void OnCollisionEnter(Collision col)
        {
            if(col.gameObject.tag == "WeaponCrate" && !_triggered)
            {
                _triggered = true;
                _cranePuzzleCompleted.Raise(true);
            }
        }
    }
}
