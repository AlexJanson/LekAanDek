using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.Puzzles.WaterCannon
{
    public class AllyShip : MonoBehaviour
    {

        [SerializeField]
        private GameObject[] _targets;

        // Start is called before the first frame update
        void Start()
        {
            _targets[0].transform.position = new Vector3(Random.Range(-7.5f, -9.5f), Random.Range(-2.25f, 1.25f), 0);
            _targets[1].transform.position = new Vector3(Random.Range(-2f, -4f), Random.Range(-2.25f, 1.25f), 0);
            _targets[2].transform.position = new Vector3(Random.Range(2.5f, 5.3f), Random.Range(-2.25f, 1.25f), 0);
            _targets[3].transform.position = new Vector3(Random.Range(-7.5f, -9.5f), Random.Range(-2.25f, 1.25f), 0);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
