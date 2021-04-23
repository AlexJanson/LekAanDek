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

        [SerializeField] [Tooltip ("Place an invisible cube here and that wil be the starting point of the line")]
        private Transform _point1;
        [SerializeField] [Tooltip ("Place an invisible cube here and that wil be the middle point of the line wich you can use to deside the hight of the line")]
        private Transform _point2;
        [SerializeField] [Tooltip ("Place an invisible cube here and that wil be the last point of the line")]
        private Transform _point3;

        [SerializeField]
        private Transform _cannonRot;

        [SerializeField]
        private LineRenderer _lineRenderer;

        [SerializeField]
        private int _vertexCount = 12;

        // Update is called once per frame
        void Update()
        {
            ChangeDistance();
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

        private void ChangeDistance()
        {
            float posY = 5 + _cannonRot.transform.rotation.x;
            _point2.transform.position = new Vector3(_point2.transform.position.x, posY, _point2.transform.position.z);
        }

    }
}