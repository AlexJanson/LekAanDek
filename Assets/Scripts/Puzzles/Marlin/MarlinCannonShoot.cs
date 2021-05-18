using System;
using UnityEngine;

namespace LekAanDek.Puzzles.Marlin
{
    /// <summary>
    /// Handles the instantiation of the projectiles.
    /// </summary>
    public class MarlinCannonShoot : MonoBehaviour
    {
        public Transform spawnPosition;
        public GameObject projectilePrefab;
        public GameObject marlinGun;

        public float lifeTime = 3.0f;
        
        public void Shoot()
        {
            var projectile = Instantiate(projectilePrefab, spawnPosition.position, marlinGun.transform.rotation);
            Destroy(projectile, lifeTime);
        }

        private void Update()
        {
            if (Input.GetKeyDown(UnityEngine.KeyCode.Space)) Shoot();
        }
    }
}
