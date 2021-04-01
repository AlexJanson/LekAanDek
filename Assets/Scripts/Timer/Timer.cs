using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.Timer
{

    /// <summary>
    /// This script is used to countdown time and call for Alarm and End events when the time is low
    /// </summary>
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private TimerSetup timer;

        private float _startTime;
        private float _currentTime;
        private float _alarmTime;

        private bool _countingDown = false;
        private bool _soundAlarm = false;
        private bool _endTime = false;
     
        // Start is called before the first frame update
        void Start()
        {
            _startTime = timer.startTime * 60;
            _alarmTime = timer.alarmTime * 60;
            timer.currentTime.Value = _startTime;
            _currentTime = timer.currentTime.Value;
        }

        // Update is called once per frame
        void Update()
        {
            if (_countingDown == true)
                CountDown();
        }

        public void StartCounting()
        {
            _countingDown = true;
        }

        private void CountDown()
        {
            _currentTime -= Time.deltaTime;

            if (_soundAlarm == false && _currentTime <= _alarmTime)
                Alarm();

            if (_endTime == false && _currentTime <= 0)
            {
                _currentTime = 0;
                End();
            }
        }

        private void Alarm()
        {
            _soundAlarm = true;
            if (_soundAlarm == true)
                timer.AlarmStarted();
        }

        private void End()
        {
            _endTime = true;
            _countingDown = false;
            if (_endTime == true)
                timer.TimerEnd();
        }
    }
}
