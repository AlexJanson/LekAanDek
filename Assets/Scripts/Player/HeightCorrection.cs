using UnityEngine;

namespace LekAanDek.Player
{
    /// <summary>
    /// This class places the player floor on the correct height for the moving boat floor surface
    /// </summary>
    public class HeightCorrection : MonoBehaviour
    {
        [SerializeField]
        private Transform _VRHead;
        [SerializeField]
        private LayerMask _floorLayer;
        [SerializeField]
        private float _rayLength = 3f;

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            Vector3 targetLocation;
            // Raycast to floor to find correct height
            if(Physics.Raycast(_VRHead.position, Vector3.down, out hit, _rayLength, _floorLayer))
            {
                // Hit point
                targetLocation = hit.point;
                // Set y position to hit point
                transform.position = new Vector3(transform.position.x, targetLocation.y, transform.position.z);
            }
        }
    }
}
