using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TouchDraw : MonoBehaviour
{
    public static bool isStopDraw = false;
    public static List<GameObject> _pointList = new List<GameObject>();
    
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private GameObject pointPositionPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private float step = 0.2f;
    [SerializeField] private GameObject firstPoint;
    [SerializeField] private float stepDistance = 2f;

    private Coroutine _drawing;
    private Coroutine _pointDraw;
    private bool isDraw;
    private Vector3 positionPoint;
    

    private void Start()
    {
        isDraw = true;
    }

    private void Update()
    {
        // if (Input.GetMouseButtonDown(0) && isDraw)
        // {
        //     StartLine();
        // }
        // if (Input.GetMouseButtonUp(0))
        // {
        //     FinishLine();
        //     isDraw = false;
        // }

        if (!isDraw)
        {
            for (int i = 0; i < _pointList.Count; i++)
            {
                transform.position = Vector3.MoveTowards(transform.position, _pointList[i].transform.position, 0.001f);
            }
        }

        if (isStopDraw)
        {
            FinishLine();
            isDraw = false;
        }
    }
    
    private void StartLine()
    {
        // if (_drawing != null && _pointDraw != null)
        // {
        //     StopCoroutine(_drawing);
        //     StopCoroutine(_pointDraw);
        // }
        
        if (_drawing != null)
        {
            StopCoroutine(_drawing);
        }

        _drawing = StartCoroutine(DrawLine());
        //_pointDraw = StartCoroutine(AddPointPosition());

    }

    private void OnMouseDown()
    {
        if (isDraw)
        {
            StartLine();
        }
    }

    private void OnMouseUp()
    {
        FinishLine();
        isDraw = false;
    }

    private void FinishLine()
    {
        StopCoroutine(_drawing);
        //StopCoroutine(_pointDraw);
    }

    private IEnumerator DrawLine()
    {
        GameObject newGameObject = Instantiate(linePrefab, Vector3.zero, 
            quaternion.identity);
        LineRenderer lineRenderer = newGameObject.GetComponent<LineRenderer>(); //поменять
        lineRenderer.positionCount = 0;

        while (true)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            
            AddPointPosition(pos);

            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
            yield return null;
        }
    }

    // private IEnumerator AddPointPosition()
    // {
    //     while(true)
    //     {
    //         Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         pos.z = 0;
    //         GameObject newPoint = Instantiate(pointPositionPrefab, pos, Quaternion.identity);
    //         _pointList.Add(newPoint);
    //     
    //         yield return new WaitForSeconds(0.3f);   
    //     }
    // }

    private void AddPointPosition(Vector3 pos)
    {
        float sqrLen = (firstPoint.transform.position - pos).sqrMagnitude;
        
        if (Mathf.Round(sqrLen) == stepDistance)
        {
            firstPoint = Instantiate(pointPositionPrefab, pos, Quaternion.identity);
        }
    }
}
