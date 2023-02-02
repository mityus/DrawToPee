using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ButtonController : MonoBehaviour
{ 
   [SerializeField] private GameObject newScene;
   [SerializeField] private GameObject nowScene;
   
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
