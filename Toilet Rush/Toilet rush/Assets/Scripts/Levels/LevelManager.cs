using System.Collections;
using System.Collections.Generic;
using Levels.Common;
using Saving;
using UnityEngine;

namespace Levels
{
   public class LevelManager : MonoBehaviour
   {
      public static LevelManager Instance { get; private set; }
   
      public List<ItemButton> itemsButtons = new List<ItemButton>();

      [SerializeField] private int level;
      [SerializeField] private int countPlayers;
      public int CountPlayers => countPlayers;
      
      
      [Header("Scene")]
      [SerializeField] private GameObject nowScene;
      [SerializeField] private GameObject winScene;
      [SerializeField] private GameObject failScene;
      
      private int _countingPlayersInLavel;
      private int _numberLevelSave = 0;

      private ButtonController _buttonController;

      public int NumberLevelSave => _numberLevelSave;
   
      private void Awake()
      {
         InformationLevel.NowLevel = level - 1;
         InformationLevel.NextLevel = level;
      
         _buttonController = gameObject.AddComponent<ButtonController>();
         InformationLevel.CounterPlayer = 0;

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

         InformationLevel.LoseStatus = 0;
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
               //Debug.Log("IsClick" + itemsButtons[i].isClick);
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

      public void ReachGoal(Transform player)
      {
         _countingPlayersInLavel++;

         if (_countingPlayersInLavel == countPlayers)
         {
            if (_numberLevelSave < level)
            {
               if (level == 50)
               {
                  _numberLevelSave = level;
                  Debug.Log(_numberLevelSave);
               }
            
               else
               {
                  _numberLevelSave = level;
                  itemsButtons[_numberLevelSave].isClick = true;
                  SaveDataLevels();
               }
            }
            
            StartCoroutine(DetaitLvl(winScene, nowScene));
            
            //_buttonController.AddScene(winScene, nowScene);
            
            Debug.Log("Win!");
         }
      }

      public void LoseLvl()
      {
         StartCoroutine(DetaitLvl(failScene, nowScene));
         
         // _buttonController.AddScene(failScene, nowScene);
         
         Debug.Log("Lose!");
         
      }

      private IEnumerator DetaitLvl(GameObject newScene, GameObject nowLvl)
      {
         yield return new WaitForSeconds(1.5f);
         
         _buttonController.AddScene(newScene, nowLvl);
      }
   }
}
