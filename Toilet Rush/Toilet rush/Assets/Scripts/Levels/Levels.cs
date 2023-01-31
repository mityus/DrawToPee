using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Levels : MonoBehaviour
{
   [SerializeField] private List<Item> startItems = new List<Item>();

   [SerializeField] private Button buttonPrefab;
   [SerializeField] private RectTransform panelLevels;
   [SerializeField] private GameObject nowScene;

   private List<Item> _levelsItem = new List<Item>();

   private ButtonLevelPrefab _buttonLevelPrefab;
   
   private ButtonController _buttonController = new ButtonController();

   private void Start()
   {
      _buttonLevelPrefab = buttonPrefab.GetComponent<ButtonLevelPrefab>();
     
      foreach (var item in startItems)
      {
         AddItem(item);
      }
      
      WindowIcons();
   }

   private void AddItem(Item item)
   {
      _levelsItem.Add(item);
   }

   private void WindowIcons()
   {
      int indexLevel = 1;
      
      foreach (var item in _levelsItem)
      {
         //_buttonLevelPrefab.textLevel.text = "LV " + _indexLevel;
         
         Button newButton = Instantiate(buttonPrefab, Vector3.zero, quaternion.identity, panelLevels);
         newButton.GetComponent<ButtonLevelPrefab>().textLevel.text = "LV " + indexLevel;
         //newButton.onClick.AddListener((() => AddLevel(item.PrefabLevel)));
         newButton.onClick.AddListener((() => _buttonController.AddScene(item.PrefabLevel, nowScene)));
         newButton.GetComponent<Button>().enabled = item.IsClick;
         
         if (item.IsClick)
         {
            newButton.GetComponent<ButtonLevelPrefab>().iconFon.sprite = item.IconLevel;
            newButton.GetComponent<ButtonLevelPrefab>().iconFon.color = Color.white;
            Destroy(newButton.GetComponent<ButtonLevelPrefab>().iconLock);
         }

         indexLevel++;
      }
   }
}
