using System;
using UnityEngine;

namespace Player
{
    public class ClashPlayers : MonoBehaviour
    {
        public static ClashPlayers Instance { get; private set; }

        [SerializeField] private GameObject failScene;
        [SerializeField] private GameObject nowScene;

        private bool _isClash;

        public bool IsClash
        {
            get => _isClash;
            set => _isClash = value;
        }

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
      
            Instance = this;
        }

        private void Start()
        {
            _isClash = false;
        }

        private void Update()
        {
            Clash();
        }

        private void Clash()
        {
            if(_isClash) ButtonController.Instance.AddScene(failScene, nowScene);
        }
    }
}
