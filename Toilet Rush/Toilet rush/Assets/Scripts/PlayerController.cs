using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static bool IsStopDraw;

    [SerializeField] private float speedMovement = 2f;
    [SerializeField] private Transform parentPoint;

    [Header("LineProperties")]
    [SerializeField] private GameObject linePrefab;
    
    [Header("PointsProperties")]
    [SerializeField] private GameObject pointPositionPrefab;
    [SerializeField] private GameObject firstPoint;
    [SerializeField] private float stepDistance = 2f;

    private bool _isDraw;
    private Coroutine _drawing;
    private Vector3 _positionPoint;
    private List<GameObject> _pointList = new List<GameObject>();
    private int _pointIndex = 0;
    private bool _isMovement;

    private Animator _animator;
    
    private Line _line = new Line();
    private void Awake()
    {
        IsStopDraw = false;
        _isDraw = true;
        firstPoint.transform.position = transform.position;
    }

    private void Start()
    {
        _positionPoint = firstPoint.transform.position;
        _animator = GetComponent<Animator>();

    }

    private void Update()
    {
        if (_isMovement)
        {
            Movement();
        }
        
        if (IsStopDraw)
        {
            FinishLine();
            _isDraw = false;
        }
    }

    private void OnMouseDown()
    {
        if (_isDraw)
        {
            StartLine();
        }
    }
    
    private void OnMouseUp()
    {
        IsStopDraw = true;
        FinishLine();
        _isDraw = false;
        _isMovement = true;
        _animator.SetBool("Run", true);
    }
    
    private void StartLine()
    {
        if (_drawing != null)
        {
            StopCoroutine(_drawing);
        }

        _drawing = StartCoroutine(DrawLine());
    }
    
    private void FinishLine()
    {
        StopCoroutine(_drawing);
    }
    
    //убрать
    private IEnumerator DrawLine()
    {
        GameObject newGameObject = Instantiate(linePrefab, Vector3.zero, 
            Quaternion.identity, gameObject.transform);
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
    
    private void AddPointPosition(Vector3 pos)
    {
        // float sqrLen = (_positionPoint - pos).sqrMagnitude;
        float sqrLen = Vector3.Distance(_positionPoint, pos);
    
        if (Mathf.Round(sqrLen) == stepDistance)
        {
            GameObject newGameObject = Instantiate(pointPositionPrefab, pos, Quaternion.identity, parentPoint);
            _pointList.Add(newGameObject);
            _positionPoint = pos;
        }
    }
    //убрать
    
    private void Movement()
    {
        if (_pointIndex < _pointList.Count)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                _pointList[_pointIndex].transform.position, speedMovement * Time.deltaTime);
            
            if (transform.position == _pointList[_pointIndex].transform.position)
            {
                _pointIndex += 1;
                Destroy(_pointList[_pointIndex - 1]);
            }
        }

        if (_pointIndex == _pointList.Count)
        {
            _pointList.Clear();
            _isMovement = false;

            LevelManager.SingltonLevelManager.ReachGoal();
        }
    }
}
