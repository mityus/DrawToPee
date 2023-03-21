using System;
using System.Collections;
using Effects;
using Player;
using UnityEngine;

namespace Obstacles
{
    public class Obstacles : MonoBehaviour
    {
        [Header("Scene")]
        [SerializeField] private GameObject newScene;
        [SerializeField] private GameObject nowScene;
        
        [Header("Effect")]
        [SerializeField] private GameObject effectManager;

        private ButtonController _buttonController;
        private EffectManager _effectManager;

        private void Awake()
        {
            _buttonController = gameObject.AddComponent<ButtonController>();
        }

        private void Start()
        {
            _effectManager = effectManager.GetComponent<EffectManager>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayFail(other);
            }
        }
        
        private IEnumerator DetaitLvl()
        {
            yield return new WaitForSeconds(3f);
         
            _buttonController.AddScene(newScene, nowScene);
        }

        private void PlayFail(Collider2D other)
        {
            Debug.Log("Fail!");
            
            _effectManager.PlayEffect(_effectManager.FailEffectPrefab, other.gameObject.transform);
            
            Destroy(other.gameObject.GetComponent<PlayerController>());

            if(gameObject.name == "Bomb") Destroy(gameObject);

            StartCoroutine(DetaitLvl());
        }
    }
}
