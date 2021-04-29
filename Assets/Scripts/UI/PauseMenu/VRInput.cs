using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

namespace LekAanDek.UI
{
    public class VRInput : BaseInput
    {
        [SerializeField]
        private Camera _eventCamera = null;

        [SerializeField]
        private SteamVR_Action_Boolean _clickAction;

        [SerializeField]
        private SteamVR_Input_Sources _targetSource;

        protected override void Awake()
        {
            GetComponent<BaseInputModule>().inputOverride = this;
        }

        public override bool GetMouseButton(int button)
        {
            return _clickAction.GetState(_targetSource);
        }

        public override bool GetMouseButtonDown(int button)
        {
            return _clickAction.GetStateDown(_targetSource);
        }

        public override bool GetMouseButtonUp(int button)
        {
            return _clickAction.GetStateUp(_targetSource);
        }

        public override Vector2 mousePosition
        {
            get
            {
                return new Vector2(_eventCamera.pixelWidth / 2, _eventCamera.pixelHeight / 2);
            }
        }
    }
}
