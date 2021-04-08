using UnityEngine;
using LekAanDek.Variables;

namespace LekAanDek.Timer
{
    /// <summary>
    /// This script displays the time left of the user on a digital watch, 
    /// There are multiple overridable functions so you can make a watch, clock, display and more of such things.
    /// </summary>
    public class BaseClock : MonoBehaviour
    {
        [Tooltip("Whether to pass through milliseconds or not.")]
        [SerializeField]
        private bool _sendMS;
        [SerializeField]
        [Tooltip("Reference to the time's scriptable object.")]
        protected FloatReference time;
        protected float _startTime = 600;

        protected string dots = ":";
        private string _fraction, _minutes, _seconds;

        private bool _runningOut;
        protected bool outOfTime;

        private void Start()
        {
            if (time != 0)
                _startTime = time;
        }

        protected virtual void Update()
        {
            if (outOfTime)
                OutOfTime();
            else if (_runningOut)
                RunningOut();
            else
                DisplayTime();
        }

        //BaseFunctions
        public string CalculateTime()
        {
            if (_sendMS)
                _fraction = ((time * 100) % 100).ToString("00");
            _minutes = Mathf.Floor(time / 60).ToString("00");
            _seconds = (time % 60).ToString("00");
            return ($"{_minutes}{dots}{_seconds}{(_sendMS ? dots + _fraction : "")}");
        }

        //Overridables
        /// <summary>
        /// Empty function for the user to add a custom way of displaying time.
        /// </summary>
        protected virtual void DisplayTime()
        {

        }
        /// <summary>
        /// This is a place where you could add special events that run when the time runs out.
        /// Within this function DisplayTime is being called from the update,
        /// Theoretically you could replace everything or just add a little bit.
        /// But I reccomend keeping in the base.
        /// </summary>
        protected virtual void RunningOut()
        {
            DisplayTime();
        }
        /// <summary>
        /// In this function you can decide what happens when the time runs out.
        /// Note: It's empty by default!
        /// </summary>
        protected virtual void OutOfTime()
        {

        }

        //Events//
        public virtual void EventOutOfTime()
        {
            outOfTime = true;
            CancelInvoke();
        }
        public virtual void EventRunningOut()
        {
            _runningOut = true;
        }
    }
}
