using UnityEngine;
using UnityEngine.XR;
using Valve.VR;


/// <summary>
/// This class should allow for playing an audio source on the watch while also vibrating to attrackt the player's attention
/// </summary>
namespace LekAanDek.Haptics
{
    public class WatchBeep : MonoBehaviour
    {
        [SerializeField]
        SteamVR_Action_Vibration _hapticSystem;
        [SerializeField]
        float _frequency = 3000;
        [SerializeField]
        float _amplitude;
        [SerializeField]
        float _duration = 1;
        [SerializeField]
        SteamVR_Input_Sources _bodyPart;

        [SerializeField]
        AudioSource _audio;
        int _delay = 0;

        public void BeepMe()
        {
            if (!_hapticSystem.active) return;
            _hapticSystem.Execute(_delay, _duration, _frequency, _amplitude, _bodyPart);
            if(_audio) _audio.Play();
        }
    }
}
