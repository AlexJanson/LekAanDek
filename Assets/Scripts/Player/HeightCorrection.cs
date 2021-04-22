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

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            float distance = 3f;
            Vector3 targetLocation;
            // Raycast to floor to find correct height
            if(Physics.Raycast(_VRHead.position, Vector3.down, out hit, distance, _floorLayer))
            {
                // Hit point
                targetLocation = hit.point;
                // Set y position to hit point
                transform.position = new Vector3(transform.position.x, targetLocation.y, transform.position.z);
            }
        }
    }
}
