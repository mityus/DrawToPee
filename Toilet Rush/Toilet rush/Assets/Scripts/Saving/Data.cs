using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int numberSaveLevel;

    public int[] itemID;
    public bool[] itemClick;

    public Data(LevelManager levelManager)
    {
        numberSaveLevel = levelManager.numberLevel;
        
        itemID = new int[levelManager.Items.Count];
        itemClick = new bool[levelManager.Items.Count];
    
        for (int i = 0; i < levelManager.Items.Count; i++)
        {
            // if (levelManager.Items[i].ID != null)
            // {
            //     itemID[i] = levelManager.Items[i].ID;
            // }
            
            itemID[i] = levelManager.Items[i].ID;
        }
        
        for (int i = 0; i < levelManager.Items.Count; i++)
        {
            itemClick[i] = levelManager.Items[i].IsClick;
        }
    }
}
