using System;
using UnityEngine;

namespace Obstacles
{
    public class ButtonHelp : MonoBehaviour
    {
        
        [SerializeField] private string namePlayer;
        [SerializeField] private string tagToilet;

        [SerializeField] private GameObject toilet;
        [SerializeField] private GameObject lockToilet;

        [SerializeField] private Color colorButtonChanged;

        private Obstacles _obstacles;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _obstacles = toilet.GetComponent<Obstacles>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == namePlayer)
            {
                OpenToilet();
                ChangeColor();
            }
        }

        private void OpenToilet()
        {
            Destroy(_obstacles);
            Destroy(lockToilet);
            
            toilet.tag = tagToilet;
            
            Destroy(gameObject);
        }

        private void ChangeColor()
        {
            _spriteRenderer.color = colorButtonChanged;
        }
    }
}
