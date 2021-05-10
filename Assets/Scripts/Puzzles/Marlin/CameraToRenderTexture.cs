using UnityEngine;

namespace LekAanDek.Puzzles.Marlin
{
    /// <summary>
    /// Takes the camera and outputs to a render texture with material.
    /// </summary>
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
