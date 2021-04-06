using UnityEngine;
using LekAanDek.Variables;

namespace LekAanDek.Waves
{
    /// <summary>
    /// Provides mathematical function for calculating the wave height.
    /// </summary>
    [CreateAssetMenu(menuName = "Custom/WaveSO", fileName = "WaveSO")]
    public class WaveSO : ScriptableObject
    {
        public FloatReference waveLength;
        public FloatReference amplitude;

        // Formula for calculating the wave height at a given position.
        public float GetWaveHeight(Vector3 position)
        {
            float k = 2 * Mathf.PI / waveLength;
            float timeAndX0 = Time.time + position.x;
            float timeAndX1 = Time.time + position.z;
            float k0 = k * timeAndX0;
            float k1 = k * timeAndX1;
            float x0 = amplitude * Mathf.Sin(k0);
            float x1 = amplitude * Mathf.Sin(k1);
            
            float height = x0 + x1;
            return height;
        }
    }
}
