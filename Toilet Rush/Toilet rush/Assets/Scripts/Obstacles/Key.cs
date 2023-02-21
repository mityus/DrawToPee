using System.Collections;
using System.Collections.Generic;
using Obstacles;
using UnityEngine;

public class Key : Loot
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        OpenToilet();
        Destroy(gameObject);
    }
}
