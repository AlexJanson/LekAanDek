using UnityEngine;

namespace LekAanDek.Waves
{
    /// <summary>
    /// Applies the physics on to a rigidbody for the buoyancy.
    /// </summary>
    public class Floater : MonoBehaviour
    {
        public new Rigidbody rigidbody;
        
        public float depthBeforeSubmerged = 1f;
        public float displacementAmount = 3f;
        public int floaterCount = 1;

        public float waterDrag = 0.99f;
        public float waterAngularDrag = 0.5f;

        public WaveSO waveSo;

        private void FixedUpdate()
        {
            Vector3 position = transform.position;
            rigidbody.AddForceAtPosition(Physics.gravity / floaterCount, position, ForceMode.Acceleration);
            float waveHeight = waveSo.GetWaveHeight(position);
            
            if (!(transform.position.y < waveHeight)) return;
            
            // Calculates the force that should be applied to the rigidbody for the buoyancy physics.
            float displacementMultiplier =
                Mathf.Clamp01((waveHeight - position.y) / depthBeforeSubmerged) * displacementAmount;
            rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y / floaterCount) * displacementMultiplier, 0f),
                position, ForceMode.Acceleration);
            rigidbody.AddForce(-rigidbody.velocity * (displacementMultiplier * waterDrag * Time.fixedDeltaTime), ForceMode.VelocityChange);
            rigidbody.AddTorque(-rigidbody.angularVelocity * (displacementMultiplier * waterAngularDrag * Time.fixedDeltaTime), ForceMode.VelocityChange);
        }
    }
}
