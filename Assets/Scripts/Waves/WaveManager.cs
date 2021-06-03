using UnityEngine;

namespace LekAanDek.Waves
{
    /// <summary>
    /// Primarily used for setting the float variable on the given shader.
    /// </summary>
    public class WaveManager : MonoBehaviour
    {
        public Material waveMaterial;
        // grabbing the propertyID of the time uniform in the shader.
        private static readonly int TimeID = Shader.PropertyToID("Time");

        private void Update() => waveMaterial.SetFloat(TimeID, Time.time);
    }
}
