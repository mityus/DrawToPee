using System;
using UnityEngine;

namespace Obstacles
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private string namePlayer;
        [SerializeField] private string tagToilet;

        [SerializeField] private GameObject toilet;
        [SerializeField] private GameObject lockToilet;

        private Obstacles _obstacles;

        private void Start()
        {
            _obstacles = toilet.GetComponent<Obstacles>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == namePlayer)
            {
                Destroy(_obstacles);
                Destroy(lockToilet);
                toilet.tag = tagToilet;
                Destroy(gameObject);
            }
        }
    }
}
