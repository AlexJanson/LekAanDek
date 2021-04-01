using UnityEngine;

namespace LekAanDek
{
    [ExecuteInEditMode]
    public class Waves : MonoBehaviour
    {
        public Texture2D baseTexture;
        public Material mat;
        public Material toMat;

        public RenderTexture rt;

        private void Start()
        {
            rt = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
        }

        private void Update()
        {
            Graphics.Blit(baseTexture, rt, mat);

            toMat.SetTexture("NoiseTexture", rt);

            
        }

        private void OnGUI()
        {
            GUI.DrawTexture(new Rect(0, 0, 256, 256), rt, ScaleMode.ScaleToFit, false, 1);
        }
    }
}
