using System;
using System.ComponentModel;
using Levels.Common;
using UnityEngine;

namespace Obstacles.Enemy
{
    public class Bomb : Obstacles
    {
        [SerializeField] private float speedMovement;

        private void Awake()
        {
            NowScene = transform.parent.gameObject;
        }

        private void Update()
        {
            transform.Translate(-speedMovement * Time.deltaTime, 0, 0);
        }
    }
}
