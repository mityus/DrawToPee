using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsPrefabs : MonoBehaviour
{
    public static LevelsPrefabs Instance { get; private set; }
    
    [SerializeField] private List<GameObject> levelPrefab = new List<GameObject>();

    public List<GameObject> LevelPrefab => levelPrefab;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
      
        Instance = this;
    }
}
