using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager SingltonLevelManager { get; private set; }
   
   [SerializeField] private int countPlayers;
   [Space] [SerializeField] private GameObject panelWin;

   private int _counter;

   private void Awake()
   {
      SingltonLevelManager = this;
   }

   private void Start()
   {
      _counter = 0;
   }

   public void ReachGoal()
   {
      _counter++;

      if (_counter == countPlayers)
      {
         Invoke("AddPanel", 1.0f);
      }
   }

   private void AddPanel()
   {
      panelWin.SetActive(true);
   }
}
