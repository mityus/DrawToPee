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
        public GameObject NowScene
        {
            get => nowScene;
            set => nowScene = value;
        }

        [Header("Effect")]
        [SerializeField] private ParticleSystem obstacleEffect;

        private ButtonController _buttonController;

        private void Awake()
        {
            _buttonController = gameObject.AddComponent<ButtonController>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Fail!");
                
                PlayFail(other);
            }

            if (gameObject.name == "Bomb")
            {
                if (other.gameObject.name == "Wall")
                {
                    Destroy(gameObject);
                }
            }
        }
        
        private IEnumerator DetaitLvl()
        {
            yield return new WaitForSeconds(1.5f);
         
            _buttonController.AddScene(newScene, nowScene);
        }

        private void PlayFail(Collider2D player)
        {
            Destroy(player.GetComponent<PlayerController>());
            
            Instantiate(obstacleEffect.gameObject, player.transform.position, Quaternion.identity, 
                gameObject.transform);
            
            StartCoroutine(DetaitLvl());
        }
    }
}
