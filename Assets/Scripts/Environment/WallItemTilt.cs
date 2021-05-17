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

        int _defaultOrientation = 0;
        void Update()
        {
            transform.eulerAngles = new Vector3(_keepDownX ? _defaultOrientation : transform.eulerAngles.x, transform.eulerAngles.y, _keepDownZ ? _defaultOrientation : transform.eulerAngles.z);
        }
    }
}
