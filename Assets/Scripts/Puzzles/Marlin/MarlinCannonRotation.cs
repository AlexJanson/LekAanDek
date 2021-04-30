using System;
using LekAanDek.Variables;
using UnityEngine;

namespace LekAanDek.Puzzles.Marlin
{
    /// <summary>
    /// Handles the rotation of the Marlin cannon.
    /// </summary>
    public class MarlinCannonRotation : MonoBehaviour
    {
        public FloatReference rotateSpeed;

        [Tooltip("Maximum horizontal rotation in degrees.")]
        [Range(0f, 70f)]
        public float horizontalMaxFov;
        [Tooltip("Maximum vertical rotation in degrees.")]
        [Range(0f, 20f)]
        public float verticalMaxFov;

        // Rotates the object around the y-axis.
        private void RotateYaw(float amount)
        {
            // Checking if the amount we want to move next is inside the maximum horizontal fov.
            if (!(transform.eulerAngles.y + amount > 360f - horizontalMaxFov / 2.0f ||
                 transform.eulerAngles.y + amount < horizontalMaxFov / 2.0f)) return;
            
            Quaternion from = transform.rotation;
            Quaternion to = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, amount, 0f));
            transform.rotation = Quaternion.Lerp(from, to, Time.time * rotateSpeed.Value);
        }

        // Rotates the object around the x-axis.
        private void RotatePitch(float amount)
        {
            // Checking if the amount we want to move next is inside the maximum vertical fov.
            if (!(transform.eulerAngles.x + amount > 360f - verticalMaxFov / 2.0f ||
                  transform.eulerAngles.x + amount < verticalMaxFov / 2.0f)) return;

            Quaternion from = transform.rotation;
            Quaternion to = Quaternion.Euler(transform.eulerAngles + new Vector3(amount, 0f, 0f));
            transform.rotation = Quaternion.Lerp(from, to, Time.time * rotateSpeed);
        }

        // API functions.
        public void RotateRight(float amount) => RotateYaw(amount);
        public void RotateLeft(float amount) => RotateYaw(-amount);
        public void RotateUp(float amount) => RotatePitch(-amount);
        public void RotateDown(float amount) => RotatePitch(amount);
        
        void OnDrawGizmosSelected()
        {
            float rayRange = 5.0f;
            float halfHorizontalMaxFov = horizontalMaxFov / 2.0f;
            float halfVerticalMaxFov = verticalMaxFov / 2.0f;
            
            Quaternion leftRayRotation = Quaternion.AngleAxis(-halfHorizontalMaxFov, Vector3.up);
            Quaternion rightRayRotation = Quaternion.AngleAxis(halfHorizontalMaxFov, Vector3.up);
            Quaternion upRayRotation = Quaternion.AngleAxis(-halfVerticalMaxFov, Vector3.right);
            Quaternion downRayRotation = Quaternion.AngleAxis(halfVerticalMaxFov, Vector3.right);
            
            Vector3 leftRayDirection = leftRayRotation * Vector3.forward;
            Vector3 rightRayDirection = rightRayRotation * Vector3.forward;
            Vector3 upRayDirection = upRayRotation * Vector3.forward;
            Vector3 downRayDirection = downRayRotation * Vector3.forward;
                
            Gizmos.color = Color.red;
            
            Gizmos.DrawRay(transform.position, leftRayDirection * rayRange);
            Gizmos.DrawRay(transform.position, rightRayDirection * rayRange);
            
            Gizmos.color = Color.blue;
            
            Gizmos.DrawRay(transform.position, upRayDirection * rayRange);
            Gizmos.DrawRay(transform.position, downRayDirection * rayRange);
            
            Gizmos.color = Color.white;
        }
    }
}
