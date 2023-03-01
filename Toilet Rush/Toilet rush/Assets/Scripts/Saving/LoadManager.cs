using System;
using UnityEngine;

namespace Saving
{
    public class LoadManager : MonoBehaviour
    {
        private void Awake()
        {
            LoadInformationGame();
        }

        private void LoadInformationGame()
        {
            SaveSystem.LoadData();
        }
    }
}
