using UnityEngine;
using Valve.VR;
using LekAanDek.Variables;

namespace LekAanDek.Puzzles.WaterCannon
{
    /// <summary>
    /// This class checks if the player is pressing the trigger button and shoots water if he does
    /// </summary>
    [RequireComponent(typeof(ParticleSystem))]
    public class ShootWater : MonoBehaviour
    {
        [SerializeField]
        private BoolVariable _startedWCPuzzle;

        [SerializeField]
        private ParticleSystem _system;

        [SerializeField]
        private SteamVR_Action_Boolean _trigger;
        [SerializeField]
        private SteamVR_Input_Sources _leftHand = SteamVR_Input_Sources.LeftHand;
        [SerializeField]
        private SteamVR_Input_Sources _rightHand = SteamVR_Input_Sources.RightHand;

        private bool _emmiting = false;

        private void Start()
        {
            _system.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }

        private void Update()
        {
            if (_trigger.GetState(_leftHand) || _trigger.GetState(_rightHand))
            {
                FiringWater();
            }
            else
            {
                _system.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }
        }
        //In this function the particle system wil be called to play and fire particles that with go down at a given speed
        private void FiringWater()
        { 
            _emmiting = (_startedWCPuzzle.Value) ? true : false;
            if (_emmiting == true)
            {
                _system.Play(true);
            }
            else if (_emmiting == false)
            {
                _system.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }
        }
    }
}
