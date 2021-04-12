using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace LekAanDek
{
    public class TestMovementCannon : MonoBehaviour
    {
        private bool grabbed;
        private Hand hand;
        private GrabTypes grabbedWithType;

        private Quaternion _delta;

        private void Start()
        {
            grabbed = false;
        }

        private void HandHoverUpdate(Hand hand)
        {
            if (hand == this.hand || !grabbed)
            {
                GrabTypes startingGrabType = hand.GetGrabStarting();
                bool isGrabEnding = hand.IsGrabbingWithType(grabbedWithType) == false;

                if (grabbedWithType == GrabTypes.None && startingGrabType != GrabTypes.None)
                {
                    grabbedWithType = startingGrabType;

                    grabbed = true;
                    this.hand = hand;

                    var lookAt = Quaternion.LookRotation(hand.hoverSphereTransform.position - transform.position);

                    _delta = Quaternion.Inverse(lookAt) * transform.rotation;
                }

                else if (grabbedWithType != GrabTypes.None && isGrabEnding)
                {
                    grabbed = false;
                    grabbedWithType = GrabTypes.None;
                    this.hand = null;

                }
            }

        }
        private void Update()
        {
            if (grabbed)
            {
                transform.rotation = Quaternion.LookRotation(hand.hoverSphereTransform.position - transform.position) * _delta;
            }
        }
    }
}
