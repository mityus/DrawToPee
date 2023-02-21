using System;
using UnityEngine;

namespace Obstacles
{
    public class ButtonHelp : Loot
    {
        [Space(10)]
        [SerializeField] private Color colorChanged;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == NamePlayer)
            {
                OpenToilet();
                ChangedColorSprite(_spriteRenderer, colorChanged);
            }
        }
    }
}
