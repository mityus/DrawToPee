using System;
using System.ComponentModel;
using Levels.Common;
using UnityEngine;

namespace Obstacles.Enemy
{
    public class Bomb : MonoBehaviour
    {
        [Header("Panels")] 
        [SerializeField] private GameObject newPanel;
        [SerializeField] private GameObject nowPanel;
        
        [SerializeField] private float speedMovement;

        private void Awake()
        {
            nowPanel = transform.parent.gameObject;
        }

        private void Update()
        {
            transform.Translate(-speedMovement * Time.deltaTime, 0, 0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(nowPanel);
            Instantiate(newPanel, nowPanel.transform.position, Quaternion.identity);
        }
    }
}
