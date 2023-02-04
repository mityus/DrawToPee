using System;

[Serializable]
public class Data
{
    public int numberSaveLevel;

    public int[] itemID;
    public bool[] itemClick;

    public Data(LevelManager levelManager)
    {
        numberSaveLevel = levelManager.NumberLevelSave;
        
        itemID = new int[levelManager.itemsButtons.Count];
        itemClick = new bool[levelManager.itemsButtons.Count];
    
        for (int i = 0; i < levelManager.itemsButtons.Count; i++)
        {
            itemID[i] = levelManager.itemsButtons[i].id;
        }
        
        for (int i = 0; i < levelManager.itemsButtons.Count; i++)
        {
            itemClick[i] = levelManager.itemsButtons[i].isClick;
        }
    }
}
