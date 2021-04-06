using UnityEngine;

namespace LekAanDek.Waves
{
    public class WaveManager : MonoBehaviour
    {
        public Material waveMaterial;
        private static readonly int TimeID = Shader.PropertyToID("Time");

        private void Update()
        {
            waveMaterial.SetFloat(TimeID, Time.time);
        }
    }
}
