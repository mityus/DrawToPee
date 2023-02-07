using UnityEngine;

public class ButtonController : MonoBehaviour
{ 
   [SerializeField] private GameObject newScene;
   [SerializeField] private GameObject nowScene;

   public void AddScene()
   {
      Destroy(nowScene);
      Instantiate(newScene, Vector3.zero, Quaternion.identity);
   }
   
   public void AddScene(GameObject newScene, GameObject nowScene)
   {
      Destroy(nowScene);
      Instantiate(newScene, Vector3.zero, Quaternion.identity);
   }
}
