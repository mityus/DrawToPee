using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
   [SerializeField] private GameObject newScene;
   [SerializeField] private GameObject nowScene;

   [SerializeField] private bool isPanelResult;
   
   private List<GameObject> _levelsList = new List<GameObject>();

   //private AudioManager _audioManager;

   private void Start()
   {
      if(isPanelResult)
      {
         foreach (GameObject lvl in LevelsPrefabs.Instance.LevelPrefab)
         {
            _levelsList.Add(lvl);
         }  
      }
   }

   public void AddScene()
   {
      Destroy(nowScene);
      Instantiate(newScene, Vector3.zero, Quaternion.identity);
   }

   public void AddScene(GameObject newScene, GameObject nowScene)
   {
      Destroy(nowScene);
      Instantiate(newScene, Vector3.zero, Quaternion.identity);
   }

   public void ReloadLvl()
   {
      Destroy(nowScene);
      Instantiate(_levelsList[InformationLevel.NowLevel], Vector3.zero, Quaternion.identity);
   }

   public void GoNewLvl()
   {
      Destroy(nowScene);
      Instantiate(_levelsList[InformationLevel.NextLevel], Vector3.zero, Quaternion.identity);
   }

   public void PlayAudio()
   {
      
   }
   
   public void SwitchOffAudio()
   {

   }
}
