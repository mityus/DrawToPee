using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private GameObject newScene;
    [SerializeField] private GameObject nowScene;
    
    private ButtonController _buttonController = new ButtonController();

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Fail!");
        _buttonController.AddScene(newScene, nowScene);
    }
}
