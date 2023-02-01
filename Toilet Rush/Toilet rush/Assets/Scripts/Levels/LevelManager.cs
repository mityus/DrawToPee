using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager SingltonLevelManager { get; private set; }

   [HideInInspector] public int numberLevel = 0;

   [SerializeField] private int level;
   [SerializeField] private int countPlayers;
   [SerializeField] private GameObject nowScene;
   [SerializeField] private GameObject newScene;
   

   private int _counter;
   
   private ButtonController _buttonController = new ButtonController();

   private void Awake()
   {
      SingltonLevelManager = this;
   }

   private void Start()
   {
      _counter = 0;
      InformationLevel.nowLevel = nowScene;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         numberLevel++;
         print(numberLevel);
      }
   }

   public void ReachGoal()
   {
      _counter++;

      if (_counter == countPlayers)
      {
         _buttonController.AddScene(newScene, nowScene);
         print("Win");
      }
   }
}
