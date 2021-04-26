using UnityEngine;

namespace LekAanDek.Waves
{
    /// <summary>
    /// This class transforms the boat model to the position and rotation calculated by the floaters (Physics based water flotation)
    /// </summary>
    public class FollowBoat : MonoBehaviour
    {
        [SerializeField]
        private Transform _realBoat;

        // Update is called once per frame
        void Update()
        {
            // Set position and transform
            transform.position = _realBoat.position;
            transform.rotation = _realBoat.rotation;
        }
    }
}
