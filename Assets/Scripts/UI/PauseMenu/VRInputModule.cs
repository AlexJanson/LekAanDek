using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;

namespace LekAanDek.UI
{
    public class VRInputModule : BaseInputModule
    {

        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private SteamVR_Input_Sources _targetSource;

        [SerializeField]
        private SteamVR_Action_Boolean _clickAction;

        private GameObject _currentObject = null;

        private PointerEventData _data = null;

        protected override void Awake()
        {
            base.Awake();

            _data = new PointerEventData(eventSystem);
        }

        public override void Process()
        {
            // Reset data
            _data.Reset();
            _data.position = new Vector2(_camera.pixelWidth / 2, _camera.pixelHeight / 2);
            
            // Raycast
            eventSystem.RaycastAll(_data, m_RaycastResultCache);
            _data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
            _currentObject = _data.pointerCurrentRaycast.gameObject;
           
            // Clear raycast
            m_RaycastResultCache.Clear();

            // Hover
            HandlePointerExitAndEnter(_data, _currentObject);

            // Press
            if (_clickAction.GetStateDown(_targetSource))
            {
                ProcessPress(_data);
            }

            // Release
            if (_clickAction.GetStateUp(_targetSource))
            {
                ProccesRelease(_data);
            }
        }

        public PointerEventData GetData()
        {
            return _data;
        }

        private void ProcessPress(PointerEventData data)
        {
            Debug.Log("pressed");
            // Set raycast
            data.pointerPressRaycast = data.pointerCurrentRaycast;

            // Check for object hit, get the down handler, call
            GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(_currentObject, data, ExecuteEvents.pointerDownHandler);
            // if no down handler, try get click handler
            if (newPointerPress == null)
                newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(_currentObject);
            // Set Data
            data.pressPosition = data.position;
            data.pointerPress = newPointerPress;
            data.rawPointerPress = _currentObject;
        }

        private void ProccesRelease(PointerEventData data)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

            GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(_currentObject);

            if(data.pointerPress == pointerUpHandler)
            {
                ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
            }

            eventSystem.SetSelectedGameObject(null);

            data.pressPosition = Vector2.zero;
            data.pointerPress = null;
            data.rawPointerPress = null;
        }
    }
}
