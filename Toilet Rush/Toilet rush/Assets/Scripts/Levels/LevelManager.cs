using System;
using System.Collections;
using System.Collections.Generic;
using Levels;
using Saving;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager Instance { get; private set; }
   
   public List<ItemButton> itemsButtons = new List<ItemButton>();

   [SerializeField] private int level;
   [SerializeField] private int countPlayers;
   [SerializeField] private GameObject nowScene;
   [SerializeField] private GameObject newScene;
   
   private int _counter;
   private int _numberLevelSave = 0;
   
   private ButtonController _buttonController = new ButtonController();

   public int NumberLevelSave => _numberLevelSave;
   
   private void Awake()
   {
      if (Instance)
      {
         Destroy(gameObject);
         return;
      }
      
      Instance = this;
   }

   private void Start()
   {
      _counter = 0;

      Load();
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
         _numberLevelSave = 0;
         Debug.Log("numberLevel: " + _numberLevelSave);
      }
   }

   private void Save()
   {
      SaveSystem.SaveData(this);
      Debug.Log("Save OK! Saving: " + _numberLevelSave);
   }
   
   private void Load()
   {
      Data data = SaveSystem.LoadData();

      _numberLevelSave = data.numberSaveLevel;
      Debug.Log("Load Ok: " + _numberLevelSave);

      if (_numberLevelSave > 0)
      {
         for (int i = 0; i < itemsButtons.Count; i++)
         {
            itemsButtons[i].isClick = data.itemClick[i];
            Debug.Log("IsClick" + itemsButtons[i].isClick);
         }  
      }
   }

   public void ReachGoal()
   {
      _counter++;

      if (_counter == countPlayers)
      {
         if (_numberLevelSave < level)
         {
            _numberLevelSave++;
            itemsButtons[_numberLevelSave].isClick = true;
            Save();
         }
         
         _buttonController.AddScene(newScene, nowScene);
         print("Win");
      }
   }
}
