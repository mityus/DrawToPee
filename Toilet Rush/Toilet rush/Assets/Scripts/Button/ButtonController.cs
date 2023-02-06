using UnityEngine;

public class ButtonController : MonoBehaviour
{ 
   [SerializeField] private GameObject newScene;
   [SerializeField] private GameObject nowScene;

   private bool isDestroyedScene = false;
   
   public void AddScene()
   {
      Instantiate(newScene, Vector3.zero, Quaternion.identity);
      Destroy(nowScene);
   }
   
   public void AddScene(GameObject newScene, GameObject nowScene)
   {
      Instantiate(newScene, Vector3.zero, Quaternion.identity);
      Destroy(nowScene);
   }
}
