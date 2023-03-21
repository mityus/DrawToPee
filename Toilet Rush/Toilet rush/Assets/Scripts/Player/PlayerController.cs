using System;
using System.Collections;
using System.Collections.Generic;
using Effects;
using Levels;
using UnityEngine;
using Line = Line.Line;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speedMovement = 2f;

        [Space] 
        [SerializeField] private string tagAim;

        [Header("LineProperties")]
        [SerializeField] private LineRenderer linePrefab;

        [Header("PointsProperties")]
        [SerializeField] private GameObject pointPrefab;
        [SerializeField] private GameObject firstPoint;
        [SerializeField] private float stepDistance = 2f;
        [SerializeField] private Transform parentPoint;
        
        [Header("EffectProperties")]
        [SerializeField] private GameObject effectManager;

        [Header("Emotion")] 
        [SerializeField] private Sprite mouthSprite;
        [SerializeField] private Sprite lipsSprite;
        [SerializeField] private GameObject mouthGameObject;
        [SerializeField] private GameObject lipsGameObject;


        private Coroutine _drawing;
        private Vector3 _positionPoint;
        private List<GameObject> _pointList = new List<GameObject>();

        private int _pointIndex = 0;

        private bool _isDraw = true;
        private bool _isMovement;
        private bool _isStopDraw = false;
        private bool _isReachAim = false;
        
        private Animator _animator;
        
        private LevelManager _levelManager;

        private EffectManager _effectManager;

        private void Awake()
        {
            firstPoint.transform.position = transform.position;
        }

        private void Start()
        {
            _levelManager = LevelManager.Instance;

            _positionPoint = firstPoint.transform.position;
            
            _animator = GetComponent<Animator>();
            
            _pointList.Add(firstPoint);

            _effectManager = effectManager.GetComponent<EffectManager>();
        }

        private void Update()
        {
            if (_isMovement)
            {
                Move();
            }
        
            if (_isStopDraw)
            {
                FinishLine();
                _isDraw = false;
            }
        }

#if UNITY_ANDROID
        private void OnMouseDown()
        {
            if (_isDraw)
            {
                StartLine();
            }
        }
    
        private void OnMouseUp()
        {
            _isStopDraw = true;
            
            InformationLevel.CounterPlayer++;
            
            FinishLine();
            
            _isDraw = false;
            _isMovement = true;
        }
#endif
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
    
        private IEnumerator DrawLine()
        {
            LineRenderer lineRenderer = Instantiate(linePrefab, Vector3.zero, 
                Quaternion.identity, gameObject.transform);
        
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
            float sqrLen = Vector3.Distance(_positionPoint, pos);
    
            if (Mathf.Round(sqrLen) == stepDistance)
            {
                GameObject newGameObject = Instantiate(pointPrefab, pos, Quaternion.identity, parentPoint);
                _pointList.Add(newGameObject);
                _positionPoint = pos;
            }
        }

        private void Move()
        {
            if (InformationLevel.CounterPlayer == _levelManager.CountPlayers)
            {
                _animator.SetBool("Run", true);
                
                if (_pointIndex < _pointList.Count)
                {
                    transform.position = Vector2.MoveTowards(transform.position, 
                        _pointList[_pointIndex].transform.position, speedMovement * Time.deltaTime);
            
                    if (transform.position == _pointList[_pointIndex].transform.position)
                    {
                        _pointIndex += 1;
                        Destroy(_pointList[_pointIndex - 1]);
                    }

                    if (transform.position == _pointList[_pointList.Count - 1].transform.position)
                    {
                        if (_isReachAim)
                        {
                            Win();
                        }
                        else
                        {
                            LevelManager.Instance.LoseLvl();
                        }
                    }
                }   
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(tagAim))  _isReachAim = true;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            InformationLevel.LoseStatus++;

            if (InformationLevel.LoseStatus == 1)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    _effectManager.PlayEffect(_effectManager.FailEffectPrefab, gameObject.transform);
                    
                    Destroy(gameObject.GetComponent<CapsuleCollider2D>());
                    Destroy(other.gameObject.GetComponent<CapsuleCollider2D>());
                    
                    Destroy(other.gameObject.GetComponent<PlayerController>());
                    Destroy(gameObject.GetComponent<PlayerController>());

                    LevelManager.Instance.LoseLvl();
                }
            }
        }

        private void ChangeSprite(GameObject go, Sprite newSprite)
        {
            go.GetComponent<SpriteRenderer>().sprite = newSprite;
        }

        private void Win()
        {
            _pointList.Clear();
            _isMovement = false;
                            
            _effectManager.PlayEffect(_effectManager.WinEffect, gameObject.transform);

            if (gameObject.name == "HaggyWaggyIdle") ChangeSprite(mouthGameObject, mouthSprite);
            else Destroy(mouthGameObject);
            
            ChangeSprite(lipsGameObject, lipsSprite);
            
            _animator.SetBool("Run", false);
            _animator.SetBool("Win", true);

            LevelManager.Instance.ReachGoal(gameObject.transform);
        }
    }
}
