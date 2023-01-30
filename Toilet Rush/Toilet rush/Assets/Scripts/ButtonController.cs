using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
   [SerializeField] private GameObject newPanel;
   [SerializeField] private GameObject prefabGameObject;

   public void AddScene()
   {
      Instantiate(newPanel, Vector3.zero, Quaternion.identity);
      Destroy(gameObject);
   }

   public void Replay()
   {
      Destroy(gameObject);
      Instantiate(prefabGameObject, Vector3.zero, Quaternion.identity);
   }
}
