using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{ 
   [SerializeField] private GameObject newScene;
   [SerializeField] private GameObject nowScene;
   
   private List<GameObject> levelsList = new List<GameObject>();

   private LevelsPrefabs _levelsPrefabs;

   private void Start()
   {
      _levelsPrefabs = gameObject.AddComponent<LevelsPrefabs>();

      foreach (var level in _levelsPrefabs.LevelPrefab)
      {
         levelsList.Add(level);
      }
      
      print(levelsList.Count);
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
