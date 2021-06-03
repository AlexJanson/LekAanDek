using LekAanDek.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.Puzzles.Crane
{
    /// <summary>
    /// This class checks whether or not the cranes weapon crate is touching both collision bars to proceed with the game
    /// </summary>
    public class GapCheck : MonoBehaviour
    {
        [SerializeField]
        private BoolEvent _cranePuzzleCompleted;
        public LayerMask cranePuzzleLayers;

        private bool _triggered = false;

        private Vector3 boxSize;

        private void Start()
        {
            MeshRenderer r = GetComponent<MeshRenderer>();
            boxSize.x = r.bounds.size.x;
            boxSize.z = r.bounds.size.z;
            // height + 0.1 to make sure the overlapBox is extended slightly lower than te boxCollider
            boxSize.y = r.bounds.size.y + 0.1f;
        }

        private void FixedUpdate()
        {
            CheckCollisions();
        }

        void CheckCollisions()
        {
            //Use the OverlapBox to detect if there are any other colliders within this box area.
            Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, boxSize / 2, Quaternion.identity, cranePuzzleLayers);
            int gapCollidersHit = 0;
            foreach(Collider col in hitColliders)
            {
                gapCollidersHit++;
            }

            // If colliding with both sides trigger the puzzle completed event
            if(gapCollidersHit == 2 && !_triggered)
            {
                _triggered = true;
                _cranePuzzleCompleted.Raise(true);
            }
        }
    }
}
