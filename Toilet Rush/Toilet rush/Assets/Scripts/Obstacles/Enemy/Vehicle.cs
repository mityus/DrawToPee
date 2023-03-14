using System;
using UnityEngine;

namespace Obstacles.Enemy
{
    public class Vehicle : MonoBehaviour,  IEnemyMovement
    {
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform finishPoint;

        [Space] 
        [SerializeField] private float speedMove;

        private string _direction;

        private void Start()
        {
            transform.position = startPoint.position;
            _direction = "Finish";
        }

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            if (_direction == "Finish")
            {
                transform.position = Vector3.MoveTowards(transform.position, finishPoint.position, 
                    speedMove * Time.deltaTime); 
            
                if (transform.position == finishPoint.position)
                {
                    _direction = "Start";
                }
            }
        
            if (_direction == "Start")
            {
                transform.position = startPoint.position;
                _direction = "Finish";
            }
        }
    }
}
