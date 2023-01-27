using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public Sprite IconLevel;
    public GameObject PrefabLevel;
    public bool IsClick;
}
