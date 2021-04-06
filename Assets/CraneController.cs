using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek
{
    public class CraneController : MonoBehaviour
    {
        [Range(0.0f, 10f)]
        [SerializeField]
        private float speed = 1f;

        private Transform crane;

        // Start is called before the first frame update
        void Start()
        {
            crane = this.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                crane.Rotate(new Vector3(0, -speed, 0));
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                crane.Rotate(new Vector3(0, speed, 0));
            }
        }
    }
}
