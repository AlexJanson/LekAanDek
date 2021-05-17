using UnityEngine;

namespace LekAanDek
{
    /// <summary>
    /// This script keeps an orientation down to make it feel like there is weight on the hanging object.
    /// </summary>
    public class WallItemTilt : MonoBehaviour
    {
        [SerializeField]
        bool _keepDownX, _keepDownZ;

        int _downOrientation = 0;
        void Update()
        {
            //This check wether the X or Y rotation must be kept down, if not they'll return to default rotation.
            transform.eulerAngles = new Vector3(_keepDownX ? _downOrientation : transform.eulerAngles.x, transform.eulerAngles.y, _keepDownZ ? _downOrientation : transform.eulerAngles.z);
        }
    }
}
