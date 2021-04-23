using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LekAanDek.Player
{
    /// <summary>
    /// This class keeps the player from sticking their head trough colliders and teleports then back
    /// </summary>
    public class AntiWallClip : MonoBehaviour
    {
        [SerializeField]
        private Transform _VRHead;
        [SerializeField]
        [Tooltip("Distance from the wall at which the position is stored")]
        private float _saveDistance = 0.18f;
        [SerializeField]
        [Tooltip("Distance from the wall at which the player is pushed back toward the previous position")]
        private float _teleportDistance = 0.12f;
        [SerializeField]
        [Tooltip("Distance the player is pushed back in the direction of the previously stored position")]
        private float _pushBackDistance = 0.06f;
        [SerializeField]
        private LayerMask _wallLayer;

        private Vector3 _lastPos;
        private bool _isInCollider;

        private void Update()
        {
            // Check if player is close to the wall and store position if they are
            if (Physics.CheckSphere(_VRHead.position, _saveDistance, _wallLayer) && !_isInCollider)
            {
                Debug.Log("first sphere entered");
                _lastPos = _VRHead.position;
                _isInCollider = true;
            }
            // Reset check if player moves away from the wall
            else if (!Physics.CheckSphere(_VRHead.position, _saveDistance, _wallLayer) && _isInCollider)
            {
                Debug.Log("RESET");
                _isInCollider = false;
            }
            // Move player back to previously stored position if they get even closer to the wall
            else if (Physics.CheckSphere(_VRHead.position, _teleportDistance, _wallLayer) && _isInCollider)
            {
                Debug.Log("PUSHBACK");
                Vector3 dir = (_VRHead.position - _lastPos).normalized;
                transform.position = transform.position - dir * _pushBackDistance;
                _isInCollider = false;
            }
        }

    }
}
