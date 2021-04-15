using UnityEngine;

namespace LekAanDek.Puzzles.Marlin
{
    public class CameraToRenderTexture : MonoBehaviour
    {

        private Camera _camera;

        public RenderTexture rt;
        public Material renderTextureMaterial;

        private void Start()
        {
            _camera = GetComponent<Camera>();

            _camera.targetTexture = rt;
            renderTextureMaterial.mainTexture = rt;
        }
    }
}
