using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Variables;
using LekAanDek.Events;

namespace LekAanDek.Timer
{
    [CreateAssetMenu(fileName = "New Timer", menuName = "ScriptableObjects/SOTimer")]
    public class TimerSetup : ScriptableObject
    {
        public float startTime;
        public FloatVariable currentTime;
        public float alarmTime;


        public VoidEvent alarmStarted;
        public VoidEvent timerEnd;
        //currenTime.value
        
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
