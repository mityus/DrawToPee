using System;
using System.Collections;
using System.Collections.Generic;
using Levels;
using Levels.Common;
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

   private int _countingPlayersInLavel;
   private int _numberLevelSave = 0;

   private ButtonController _buttonController;

   public int NumberLevelSave => _numberLevelSave;
   
   private void Awake()
   {
      _buttonController = gameObject.AddComponent<ButtonController>();
      
      if (Instance)
      {
         Destroy(gameObject);
         return;
      }
      
      Instance = this;
   }

   private void Start()
   {
      _countingPlayersInLavel = 0;

      LoadDataLevels();
   }

   private void Update()
   {
      if (Input.GetKeyDown(InputConfig.SaveKey))
      {
         SaveDataLevels();
      }
      
      if (Input.GetKeyDown(InputConfig.LoadKey))
      {
         LoadDataLevels();
      }
      
      if (Input.GetKeyDown(InputConfig.ResetSave))
      {
        ResetData();
      }
   }

   private void SaveDataLevels()
   {
      SaveSystem.SaveData(this);
      Debug.Log("Save OK! Saving: " + _numberLevelSave);
   }
   
   private void LoadDataLevels()
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

   private void ResetData()
   {
      _numberLevelSave = 0;
      Debug.Log("Reset OK! numberLevel: " + _numberLevelSave);

      for (int i = 1; i < itemsButtons.Count; i++)
      {
         itemsButtons[i].isClick = false;
      }
   }

   public void ReachGoal()
   {
      _countingPlayersInLavel++;

      if (_countingPlayersInLavel == countPlayers)
      {
         if (_numberLevelSave < level)
         {
            _numberLevelSave++;
            itemsButtons[_numberLevelSave].isClick = true;
            SaveDataLevels();
         }
         
         _buttonController.AddScene(newScene, nowScene);
         Debug.Log("Win!");
      }
   }
}
