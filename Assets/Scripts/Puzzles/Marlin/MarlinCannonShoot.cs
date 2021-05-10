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
        
        public void Shoot() => Instantiate(projectilePrefab, spawnPosition.position, transform.rotation);

        private void Update()
        {
            if (Input.GetKeyDown(UnityEngine.KeyCode.Space)) Shoot();
        }
    }
}
