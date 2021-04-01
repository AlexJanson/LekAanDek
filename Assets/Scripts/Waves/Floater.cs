using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek
{
    public class Floater : MonoBehaviour
    {
        Waves waves;
        public Texture2D tex;
        public Color col;

        private void Start()
        {
            waves = FindObjectOfType<Waves>();
        }

        private void Update()
        {
            tex = new Texture2D(1024, 1024, TextureFormat.ARGB32, false);
            RenderTexture.active = waves.rt;
            tex.ReadPixels(new Rect(0, 0, waves.rt.width, waves.rt.height), 0, 0);
            tex.Apply();

            col = tex.GetPixel((int)transform.position.x, (int)transform.position.z);
            float height = Mathf.Lerp(-1, 1, col.r);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = col;
            Gizmos.DrawSphere(transform.position, .1f);
        }
    }
}
