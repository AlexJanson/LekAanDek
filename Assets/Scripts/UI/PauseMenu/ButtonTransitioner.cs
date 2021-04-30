using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

namespace LekAanDek.UI
{
    public class ButtonTransitioner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
    {

        [SerializeField]
        private Color32 _normalColor = Color.white;
        [SerializeField]
        private Color32 _hoverColor = Color.red;
        [SerializeField]
        private Color32 _downColor = Color.white;
        [SerializeField]
        private UnityEvent OnClick = new UnityEvent();

        private Image _image = null;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            print("hovering");
            _image.color = _hoverColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _image.color = _normalColor;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _image.color = _downColor;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick.Invoke();
            _image.color = _hoverColor;
        }
    }
}
