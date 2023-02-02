using System;
using System.Collections;
using System.Collections.Generic;
using Saving;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager SingltonLevelManager { get; private set; }
   
   public List<Item> Items = new List<Item>();

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
      //InformationLevel.nowLevel = nowScene;

      Load();
      //not load data for the first time
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.A))
      {
         Save();
      }
      
      if (Input.GetKeyDown(KeyCode.W))
      {
         Load();
      }
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
         numberLevel = 0;
         Debug.Log("numberLevel: " + numberLevel);
      }
   }

   private void Save()
   {
      SaveSystem.SaveData(this);
      Debug.Log("Save OK! Saving: " + numberLevel);
   }
   
   private void Load()
   {
      Data data = SaveSystem.LoadData();

      numberLevel = data.numberSaveLevel;
      Debug.Log("Load Ok: " + numberLevel);

      if (numberLevel > 0)
      {
         for (int i = 0; i < Items.Count; i++)
         {
            Items[i].IsClick = data.itemClick[i];
            Debug.Log("IsClick" + Items[i].IsClick);
         }  
      }
   }

   public void ReachGoal()
   {
      _counter++;

      if (_counter == countPlayers)
      {
         if (numberLevel < level)
         {
            numberLevel++;
            Items[numberLevel].IsClick = true;
            Save();
         }
         
         _buttonController.AddScene(newScene, nowScene);
         print("Win");
      }
   }
}
