using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{ 
   [SerializeField] private GameObject newScene;
   [SerializeField] private GameObject nowScene;
   
   private List<GameObject> _levelsList = new List<GameObject>();

   private void Start()
   {
      foreach (GameObject lvl in LevelsPrefabs.Instance.LevelPrefab)
      {
         _levelsList.Add(lvl);
      }
   }

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
