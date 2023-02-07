using System;
using System.Collections;
using UnityEngine;

namespace Obstacles.Enemy
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private GameObject parent;
        
        [SerializeField] private float timeInterval;

        [SerializeField] private GameObject bombPrefab;

        [SerializeField] private Transform targetBomb;

        private void Start()
        {
            StartCoroutine(CreateBomb());
        }

        private IEnumerator CreateBomb()
        {
            while (true)
            {
                Instantiate(bombPrefab, targetBomb.position, Quaternion.identity, parent.transform);
                
                yield return new WaitForSeconds(timeInterval);
            }
        }
    }
}
