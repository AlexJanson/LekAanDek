using UnityEngine;
using LekAanDek.Variables;
using LekAanDek.Events;

namespace LekAanDek.Timer
{
    /// <summary>
    /// This is a scriptable object that holds multiple values for the timer and events that will fire a Raise when requested
    /// </summary>
    [CreateAssetMenu(fileName = "New Timer", menuName = "ScriptableObjects/SOTimer")]
    public class TimerSetup : ScriptableObject
    {
        public float startTime;
        public FloatVariable currentTime;
        public float alarmTime;

        public BoolVariable countingDown;

        public VoidEvent alarmStarted;
        public VoidEvent timerEnd;
        
        public void AlarmStarted()
        {
            alarmStarted.Raise();
        }

        public void TimerEnd()
        {
            timerEnd.Raise();
        }
    }
}
