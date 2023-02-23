using System;
using Obstacles.Enemy;
using UnityEngine;

namespace Obstacles
{
    public class LevelArm : MonoBehaviour
    {
        [SerializeField] private GameObject parentObject;

        [Space] [SerializeField] private GameObject monsterGameObject;
        
        private Animator _animator;

        private Monster _monster;

        private void Start()
        {
            _animator = parentObject.GetComponent<Animator>();

            _monster = monsterGameObject.GetComponent<Monster>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _animator.SetBool("isChangeArm", true);
            
            StopMonster();
        }

        private void StopMonster()
        {
            Destroy(_monster);
        }
    }
}
