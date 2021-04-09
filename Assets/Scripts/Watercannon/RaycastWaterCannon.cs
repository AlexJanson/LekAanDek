using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.WaterCannon
{
    public class RaycastWaterCannon : MonoBehaviour
    {

        [SerializeField]
        private CannonMovement cm;

        public Transform point1;
        public Transform point2;
        public Transform point3;
        public LineRenderer lineRenderer;
        public int vertexCount = 12;

        // Update is called once per frame
        void Update()
        {
           if(cm.puzzleStarted == true)
            {
                DrawLine();
            }
        }

        private void DrawLine()
        {
            var pointList = new List<Vector3>();
            for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
            {
                var tangentLineVertex1 = Vector3.Lerp(point1.localPosition, point2.localPosition, ratio);
                var tangentLineVertex2 = Vector3.Lerp(point2.localPosition, point3.localPosition, ratio);
                var bezierpoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
                pointList.Add(bezierpoint);
            }
            lineRenderer.positionCount = pointList.Count;
            lineRenderer.SetPositions(pointList.ToArray());
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(point1.position, point2.position);

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(point2.position, point3.position);

            Gizmos.color = Color.red;
            for (float ratio = 0.5f / vertexCount;ratio<1;ratio += 1.0f / vertexCount)
            {
                Gizmos.DrawLine(Vector3.Lerp(point1.position, point2.position, ratio), Vector3.Lerp(point2.position, point3.position, ratio));
            }
        }

    }
}
