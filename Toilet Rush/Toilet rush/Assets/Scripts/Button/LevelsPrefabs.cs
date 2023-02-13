using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsPrefabs : MonoBehaviour
{
   [SerializeField] private List<GameObject> levelPrefab = new List<GameObject>();

   public List<GameObject> LevelPrefab => levelPrefab;
}
