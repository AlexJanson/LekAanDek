using UnityEngine;
using LekAanDek.Variables;

namespace LekAanDek.Timer
{
    /// <summary>
    /// This script is used to countdown time and call for Alarm and End events when the time is low
    /// </summary>
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private TimerSetup _timer;

        private float _startTime;
        private FloatVariable _currentTime;
        private float _alarmTime;

        [SerializeField]
        private BoolVariable _gameHasStarted;
        private BoolVariable _countingDown;
        private bool _soundAlarm = false;
        private bool _endTime = false;
     
        // Start is called before the first frame update
        void Start()
        {
            _countingDown = _timer.countingDown;
            _countingDown.Value = true;
            _startTime = _timer.startTime * 60;
            _alarmTime = _timer.alarmTime * 60;
            _timer.currentTime.Value = _startTime;
            _currentTime = _timer.currentTime;
        }

        // Update is called once per frame
        void Update()
        {
            if (_countingDown.Value && _gameHasStarted.Value)
                CountDown();
        }

        private void CountDown()
        {
            _currentTime.Value -= Time.deltaTime;
            print(_currentTime.Value);
            if (_soundAlarm == false && _currentTime.Value <= _alarmTime)
                Alarm();

            if (_endTime == false && _currentTime.Value <= 0)
            {
                _currentTime.Value = 0;
                End();
            }
        }

        private void Alarm()
        {
            _soundAlarm = true;
            if (_soundAlarm == true)
                _timer.AlarmStarted();
        }

        private void End()
        {
            _endTime = true;
            _countingDown.Value = false;
            if (_endTime == true)
                _timer.TimerEnd();
        }
    }
}
