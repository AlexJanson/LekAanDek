using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using LekAanDek.Events;

namespace LekAanDek
{
    public class VRPointer : MonoBehaviour
    {
        public SteamVR_LaserPointer laserPointer;

        [SerializeField]
        private Button[] _buttons;

        private Color _color;

        void Awake()
        {
            laserPointer.PointerIn += PointerInside;
            laserPointer.PointerOut += PointerOutside;
            laserPointer.PointerClick += PointerClick;
        }

        public void PointerClick(object sender, PointerEventArgs e)
        {
            if (e.target.name == _buttons[0].name)
            {
                _buttons[0].GetComponent<Button>().onClick.Invoke();
            }
            else if (e.target.name == _buttons[1].name)
            {
                _buttons[1].GetComponent<Button>().onClick.Invoke();
            }
            else if (e.target.name == _buttons[2].name)
            {
                _buttons[2].GetComponent<Button>().onClick.Invoke();
            }
        }

        public void PointerInside(object sender, PointerEventArgs e)
        {
            if (e.target.name == _buttons[0].name)
            {
                _buttons[0].GetComponent<Image>().color = Color.blue;
            }
            else if (e.target.name == _buttons[1].name)
            {
                _buttons[1].GetComponent<Image>().color = Color.blue;
            }
            else if (e.target.name == _buttons[2].name)
            {
                _buttons[2].GetComponent<Image>().color = Color.blue;
            }
        }

        public void PointerOutside(object sender, PointerEventArgs e)
        {
            if (e.target.name == _buttons[0].name)
            {
                _buttons[0].GetComponent<Image>().color = Color.white;
            }
            else if (e.target.name == _buttons[1].name)
            {
                _buttons[1].GetComponent<Image>().color = Color.white;
            }
            else if (e.target.name == _buttons[2].name)
            {
                _buttons[2].GetComponent<Image>().color = Color.white;
            }
        }
    }
}
