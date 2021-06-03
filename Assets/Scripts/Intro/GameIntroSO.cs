using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Events;

namespace LekAanDek.Intro
{
    /// <summary>
    /// This holds all of the parts for the intro.
    /// </summary>
    [CreateAssetMenu(fileName = "IntroParts", menuName = "Custom/IntroParts")]
    public class GameIntroSO : ScriptableObject
    {
        public List<IntroPart> introParts = new List<IntroPart>();
    }

    public enum OfficerAnimation
    {
        Idle, Talking, Pointing
    }

    [System.Serializable]
    public class IntroPart
    {
        public AudioClip clip;
        public float waitDuration;
        public OfficerAnimation animation;
        public VoidEvent partCompletedEvent;
    }
}
