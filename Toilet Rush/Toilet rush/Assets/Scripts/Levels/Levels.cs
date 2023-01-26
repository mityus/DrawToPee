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

   private List<Item> _levelsItem = new List<Item>();

   private ButtonLevelPrefab _buttonLevelPrefab;

   private int _indexLevel = 1;

   private void Start()
   {
      _buttonLevelPrefab = buttonPrefab.GetComponent<ButtonLevelPrefab>();
      
      for (int i = 0; i < startItems.Count; i++)
      {
         AddItem(startItems[i]);  
      }
      
      WindowIcons();
   }

   private void AddItem(Item item)
   {
      _levelsItem.Add(item);
   }

   private void WindowIcons()
   {
      for (int i = 0; i < _levelsItem.Count; i++)
      {
         // Button newButton = Instantiate(buttonPrefab, Vector3.zero, quaternion.identity, panelLevels);
         //
         // if (i == 0)
         // {
         //    newButton.GetComponent<ButtonLevelPrefab>().iconFon.sprite = _levelsItem[0].IconLevel;
         // }
         
         _buttonLevelPrefab.textLevel.text = "LV " + _indexLevel;
         
         Instantiate(buttonPrefab, Vector3.zero, quaternion.identity, panelLevels);

         _indexLevel++;
      }
      
   }
}
