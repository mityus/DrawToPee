using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
   [SerializeField] private GameObject newPanel;
   [SerializeField] private GameObject prefabGameObject;
   [SerializeField] private GameObject panelWin;

   public void AddScene()
   {
      Instantiate(newPanel, Vector3.zero, Quaternion.identity);
      Destroy(gameObject);
   }

   public void Replay()
   {
      Instantiate(prefabGameObject, Vector3.zero, Quaternion.identity);
      Destroy(gameObject);
      panelWin.SetActive(false);
   }
}
