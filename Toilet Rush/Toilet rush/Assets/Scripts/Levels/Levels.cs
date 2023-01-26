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
   private List<Button> _listButton = new List<Button>();

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
      for (int i = 0; i < _levelsItem.Count - 1; i++)
      {
         //_buttonLevelPrefab.textLevel.text = "LV " + _indexLevel;
         
         Button newButton = Instantiate(buttonPrefab, Vector3.zero, quaternion.identity, panelLevels);
         newButton.GetComponent<ButtonLevelPrefab>().textLevel.text = "LV " + _indexLevel;
         newButton.onClick.AddListener((() => AddLevel(_levelsItem[i].PrefabLevel)));

         _listButton.Add(newButton);
         
         _indexLevel++;
      }

      // настройка первой кнопки, появление картинки и т.д.
      
      ButtonLevelPrefab firstButton = _listButton[0].GetComponent<ButtonLevelPrefab>();
      firstButton.iconFon.sprite = _levelsItem[0].IconLevel;
      firstButton.iconFon.color = Color.white;
      Destroy(firstButton.iconLock);

   }

   private void AddLevel(GameObject newPanel)
   {
      Instantiate(newPanel, Vector3.zero, Quaternion.identity);
      //Destroy(gameObject);
   }
}
