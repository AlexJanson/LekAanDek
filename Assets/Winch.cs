using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.CranePuzzle
{
    public class Winch : MonoBehaviour
    {
        [SerializeField]
        private Transform attachedObject;
        [SerializeField]
        private float maxLimit = 6f;
        [SerializeField]
        private float minLimit = 0.1f;
        [Range(0.0f, 1f)]
        [SerializeField]
        private float speed = 1f;

        LineRenderer lr;
        ConfigurableJoint joint;

        // Start is called before the first frame update
        void Start()
        {
            lr = this.GetComponent<LineRenderer>();
            joint = attachedObject.GetComponent<ConfigurableJoint>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                SoftJointLimit limit = joint.linearLimit;
                limit.limit = limit.limit -= speed;
                joint.linearLimit = limit;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                SoftJointLimit limit = joint.linearLimit;
                limit.limit = limit.limit += speed;
                joint.linearLimit = limit;
            }

            UpdateLine();
        }

        // Updates the line renderer to always be attached to the attached object
        void UpdateLine()
        {
            // Set starting position
            lr.SetPosition(0, this.transform.position);
            // Set end position
            lr.SetPosition(1, attachedObject.position);
        }
    }
}
