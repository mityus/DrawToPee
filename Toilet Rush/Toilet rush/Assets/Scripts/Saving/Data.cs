using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int numberSaveLevel;

    public Data(LevelManager levelManager)
    {
        numberSaveLevel = levelManager.numberLevel;
    }
}
