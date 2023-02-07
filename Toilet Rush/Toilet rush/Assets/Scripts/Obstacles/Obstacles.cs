using UnityEngine;

namespace Obstacles
{
    public class Obstacles : MonoBehaviour
    {
        [SerializeField] private GameObject newScene;
        [SerializeField] private GameObject nowScene;

        private ButtonController _buttonController;

        private void Awake()
        {
            _buttonController = gameObject.AddComponent<ButtonController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Fail!");
            _buttonController.AddScene(newScene, nowScene);
        }
    }
}
