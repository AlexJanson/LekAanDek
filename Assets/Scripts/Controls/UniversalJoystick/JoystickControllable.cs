using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.Controls
{
    /// <summary>
    /// Is the base class for any objects that can be controlled with the UniversalJoystick
    /// </summary>
    public abstract class JoystickControllable : MonoBehaviour
    {
        // API functions.
        public void RotateRight(float amount) => RotateYaw(amount);
        public void RotateLeft(float amount) => RotateYaw(-amount);
        public void RotateUp(float amount) => RotatePitch(-amount);
        public void RotateDown(float amount) => RotatePitch(amount);
        public virtual void RotatePitch(float amount)
        {
            throw new System.NotImplementedException();
        }
        public virtual void RotateYaw(float amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
