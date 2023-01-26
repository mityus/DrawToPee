using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager SingltonLevelManager { get; private set; }
   
   [SerializeField] private int countPlayers;

   private int counter;

   private void Awake()
   {
      SingltonLevelManager = this;
   }

   private void Start()
   {
      counter = 0;
   }

   public void ReachGoal()
   {
      counter++;

      if (counter == countPlayers)
      {
         print("Win");
      }
   }
}
