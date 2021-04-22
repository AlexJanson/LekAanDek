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
        private float _pushBackDistance = 0.06f;
        [SerializeField]
        private LayerMask _wallLayer;

        private Vector3 _lastPos;
        private bool _isInCollider;

        private void Update()
        {
            // Check if player is close to wall and store position if they are
            if (Physics.CheckSphere(_VRHead.position, 0.18f, _wallLayer) && !_isInCollider)
            {
                Debug.Log("first sphere entered");
                _lastPos = _VRHead.position;
                _isInCollider = true;
            } 
            // Move player back to previously stored position if they get even closer to the wall
            else if (Physics.CheckSphere(_VRHead.position, 0.12f, _wallLayer) && _isInCollider)
            {
                Debug.Log("PUSHBACK");
                Vector3 dir = (_VRHead.position - _lastPos).normalized;
                transform.position = transform.position - dir * _pushBackDistance;
                _isInCollider = false;
            }
        }

    }
}
