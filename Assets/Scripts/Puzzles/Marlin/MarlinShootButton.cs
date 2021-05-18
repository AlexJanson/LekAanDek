using LekAanDek.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek
{
    public class MarlinShootButton : MonoBehaviour
    {
        [SerializeField]
        private VoidEvent _shootMarlin;

        public void Shoot() => _shootMarlin.Raise();
    }
}
