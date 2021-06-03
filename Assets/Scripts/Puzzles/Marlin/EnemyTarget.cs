using LekAanDek.Variables;
using UnityEngine;

namespace LekAanDek.Puzzles.Marlin
{
    public class EnemyTarget : MonoBehaviour
    {
        public BoolVariable targetHit;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Projectile projectile)) return;
            Destroy(projectile.gameObject);
            targetHit.Value = true;
            gameObject.SetActive(false);
        }
    }
}
