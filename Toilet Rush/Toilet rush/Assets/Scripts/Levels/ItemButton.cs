using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/Item")]
    public class ItemButton : ScriptableObject
    {
        public int id;
        public Sprite iconLevel;
        public GameObject prefabLevel;
        public bool isClick;
    }
}
