using UnityEngine;

namespace LekAanDek.Timer
{
    /// <summary>
    /// This script is for an optional analog clock, it takes quite a bit from the base.
    /// </summary>
    public class AnalogClock : BaseClock
    {
        [Tooltip("Reference to the clock's rotational point.")]
        [SerializeField]
        private GameObject _rotatingPoint;
        [SerializeField]
        [Tooltip("This is how fast the hand jumps between seconds.")]
        private float _handSpeed = 5;

        protected override void Update()
        {
            base.Update();
        }

        protected override void DisplayTime()
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(((int)time / _startTime * 360), 0, 0), _handSpeed * Time.deltaTime);
        }

        protected override void RunningOut()
        {
            //Something neat could come here
            base.RunningOut();
        }

        protected override void OutOfTime()
        {
            //Think of something fun ;)
        }
    }
}
