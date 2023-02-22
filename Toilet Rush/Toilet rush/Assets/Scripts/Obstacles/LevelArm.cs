using System;
using UnityEngine;

namespace Obstacles
{
    public class LevelArm : MonoBehaviour
    {
        [SerializeField] private GameObject parentObject;
        
        private Animator _animator;

        private void Start()
        {
            _animator = parentObject.GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _animator.SetBool("isChangeArm", true);
        }
    }
}
