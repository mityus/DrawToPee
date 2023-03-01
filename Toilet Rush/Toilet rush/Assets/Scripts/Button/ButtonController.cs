using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
   [SerializeField] private GameObject newScene;
   [SerializeField] private GameObject nowScene;

   [SerializeField] private bool isPanelResult;
   
   private List<GameObject> _levelsList = new List<GameObject>();

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
      AudioSource audioBackground = FindObjectOfType<AudioSource>();
      AudioSource audioComponent = audioBackground.GetComponent<AudioSource>();

      if (!audioComponent.enabled)
      {
         audioComponent.enabled = true;
      }
   }

   public void SwitchOffAudio()
   {
      AudioSource audioBackground = FindObjectOfType<AudioSource>();
      AudioSource audioComponent = audioBackground.GetComponent<AudioSource>();

      if (audioComponent.enabled)
      {
         audioComponent.enabled = false;
      }
   }
}
