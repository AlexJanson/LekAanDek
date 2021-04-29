using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LekAanDek.UI
{
    public class CanvasPointer : MonoBehaviour
    {

        [SerializeField]
        private float _defaultLength = 3.0f;

        private LineRenderer _lineRenderer = null;

        [SerializeField]
        private EventSystem _eventSystem = null;
        [SerializeField]
        private StandaloneInputModule _inputModule = null;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateLength();
        }

        private void UpdateLength()
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, GetEnd());
        }

        private Vector3 GetEnd()
        {
            float distance = GetCanvasDistance();
            Vector3 endPosition = CalculateEnd(_defaultLength);

            if (distance != 0.0f)
                endPosition = CalculateEnd(distance);

            return endPosition;
        }

        private float GetCanvasDistance()
        {
            //Get data
            PointerEventData eventData = new PointerEventData(_eventSystem);
            eventData.position = _inputModule.inputOverride.mousePosition;

            //Raycast ysing data
            List<RaycastResult> results = new List<RaycastResult>();
            _eventSystem.RaycastAll(eventData, results);

            //Get closest
            RaycastResult closestResult = FindFirstRaycast(results);
            float distance = closestResult.distance;

            //Clamp
            distance = Mathf.Clamp(distance, 0.0f, _defaultLength);
            return distance;
        }

        private RaycastResult FindFirstRaycast(List<RaycastResult> results)
        {
            foreach(RaycastResult result in results)
            {
                if (result.gameObject)
                    continue;

                return result;
            }

            return new RaycastResult();
        }

        private Vector3 CalculateEnd(float length)
        {
            return transform.position + (transform.forward * length);
        }
    }
}
