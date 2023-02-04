using System.Collections.Generic;
using Saving;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Levels
{
   public class LevelsView : MonoBehaviour
   {
      [SerializeField] private List<ItemButton> startItems = new List<ItemButton>();
      [SerializeField] private Button buttonPrefab;
      [SerializeField] private RectTransform panelLevels;
      [SerializeField] private GameObject nowScene;

      private List<ItemButton> _levelsItem = new List<ItemButton>();

      private ButtonController _buttonController = new ButtonController();

      private void Start()
      {
         foreach (var item in startItems)
         {
            AddItem(item);
         }
      
         WindowIcons();
      }

      private void AddItem(ItemButton itemButton)
      {
         _levelsItem.Add(itemButton);
      }

      private void WindowIcons()
      {
         foreach (var item in _levelsItem)
         {
            //_buttonLevelPrefab.textLevel.text = "LV " + _indexLevel;
         
            Button newButton = Instantiate(buttonPrefab, Vector3.zero, quaternion.identity, panelLevels);
            newButton.GetComponent<ButtonLevelPrefab>().textLevel.text = "LV " + item.id;
            //newButton.onClick.AddListener((() => AddLevel(item.PrefabLevel)));
            newButton.onClick.AddListener((() => _buttonController.AddScene(item.prefabLevel, nowScene)));
            newButton.enabled = item.isClick;
         
            if (item.isClick)
            {
               ButtonLevelPrefab buttonComponent = newButton.GetComponent<ButtonLevelPrefab>();
               buttonComponent.iconFon.sprite = item.iconLevel;
               buttonComponent.iconFon.color = Color.white;
               Destroy(buttonComponent.iconLock);
            }
         }
      }
   }
}
