using System;
using UnityEngine;

namespace Saving
{
    public class LoadManager : MonoBehaviour
    {
        private bool isFirstStart;
        public bool IsFirstStart => isFirstStart;

        private void Awake()
        {
            if (!isFirstStart)
            {
                SaveSystem.CreateDataFile(this);
            }
        }
    }
}
