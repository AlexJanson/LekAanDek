using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.Intro
{
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
    }
}
