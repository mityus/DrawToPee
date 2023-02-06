using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform finishPoint;

    [Space] 
    [SerializeField] private float speedMove;

    private string direction;

    private void Start()
    {
        transform.position = startPoint.position;
        direction = "Finish";
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (direction == "Finish")
        {
            transform.position = Vector3.MoveTowards(transform.position, finishPoint.position, 
                speedMove * Time.deltaTime); 
            
            if (transform.position == finishPoint.position)
            {
                direction = "Start";
            }
        }

        if (direction == "Start")
        {
            transform.position = startPoint.position;
            direction = "Finish";
        }
    }
}
