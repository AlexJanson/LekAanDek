using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Variables;

namespace LekAanDek.Puzzles.WaterCannon
{
    /// <summary>
    /// In this script an line is made where you can ajust the 3 points to change the hight and length of the linerenderer
    /// </summary>
    public class RaycastWaterCannon : MonoBehaviour
    {

        [SerializeField]
        private BoolVariable _startedWCPuzzle;

        [SerializeField]
        private Transform _point1;
        [SerializeField]
        private Transform _point2;
        [SerializeField]
        private Transform _point3;

        [SerializeField]
        private LineRenderer _lineRenderer;

        [SerializeField]
        private int _vertexCount = 12;

        // Update is called once per frame
        void Update()
        {
            if (_startedWCPuzzle.Value == true)
            {
                _lineRenderer.enabled = true;
                DrawLine();
            }
            else
            {
                _lineRenderer.enabled = false;
            }
        }

        private void DrawLine()
        {
            var pointList = new List<Vector3>();
            for (float ratio = 0; ratio <= 1; ratio += 1.0f / _vertexCount)
            {
                var tangentLineVertex1 = Vector3.Lerp(_point1.localPosition, _point2.localPosition, ratio);
                var tangentLineVertex2 = Vector3.Lerp(_point2.localPosition, _point3.localPosition, ratio);
                var bezierpoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
                pointList.Add(bezierpoint);
            }
            _lineRenderer.positionCount = pointList.Count;
            _lineRenderer.SetPositions(pointList.ToArray());
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_point1.position, _point2.position);

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(_point2.position, _point3.position);

            Gizmos.color = Color.red;
            for (float ratio = 0.5f / _vertexCount;ratio<1;ratio += 1.0f / _vertexCount)
            {
                Gizmos.DrawLine(Vector3.Lerp(_point1.position, _point2.position, ratio), Vector3.Lerp(_point2.position, _point3.position, ratio));
            }
        }

    }
}