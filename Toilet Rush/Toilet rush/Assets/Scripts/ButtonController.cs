using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
   [SerializeField] private GameObject newPanel;

   public void AddScene()
   {
      Instantiate(newPanel, Vector3.zero, Quaternion.identity);
      Destroy(gameObject);
   }
}
