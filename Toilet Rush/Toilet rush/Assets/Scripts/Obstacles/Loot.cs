using System;
using UnityEngine;

namespace Obstacles
{
    public class Loot : MonoBehaviour
    {
        [SerializeField] private string namePlayer;
        protected string NamePlayer => namePlayer;
        
        [SerializeField] private string tagToilet;

        [SerializeField] private GameObject toilet;
        [SerializeField] private GameObject lockToilet;

        protected void OpenToilet()
        {
            Destroy(lockToilet);
            
            toilet.tag = tagToilet;
        }

        protected void ChangedColorSprite(SpriteRenderer spriteRenderer, Color colorChanged)
        {
            spriteRenderer.color = colorChanged;
        }
    }
}
