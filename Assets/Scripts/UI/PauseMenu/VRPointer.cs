using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

namespace LekAanDek
{
    public class VRPointer : MonoBehaviour
    {
        [SerializeField]
        private SteamVR_LaserPointer _laserPointer;

        [SerializeField]
        private Button[] _buttons;

        [SerializeField]
        private AudioSource _hoverSound;

        void Awake()
        {
            _laserPointer.PointerIn += PointerInside;
            _laserPointer.PointerOut += PointerOutside;
            _laserPointer.PointerClick += PointerClick;
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
                _hoverSound.Play();
            }
            else if (e.target.name == _buttons[1].name)
            {
                _buttons[1].GetComponent<Image>().color = Color.blue;
                _hoverSound.Play();
            }
            else if (e.target.name == _buttons[2].name)
            {
                _buttons[2].GetComponent<Image>().color = Color.blue;
                _hoverSound.Play();
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
