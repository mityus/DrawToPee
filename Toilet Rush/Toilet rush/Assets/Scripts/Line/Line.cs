using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Line
{
    public class Line : MonoBehaviour
    {
        private LineRenderer _linePrefab;
        private float _stepDistance;
        private List<GameObject> _pointList;
        private GameObject _pointPrefab;
        private Transform _parentPoint;
    
        public Line(LineRenderer linePrefab, float stepDistance, List<GameObject> pointList, 
            GameObject pointPrefab, Transform parentPoint)
        {
            _linePrefab = linePrefab;
            _stepDistance = stepDistance;
            _pointList = pointList;
            _pointPrefab = pointPrefab;
            _parentPoint = parentPoint;
        }
    
        public IEnumerator DrawLine(Vector3 positionPoint)
        {
            LineRenderer lineRenderer = Instantiate(_linePrefab, Vector3.zero, 
                Quaternion.identity, gameObject.transform);
        
            lineRenderer.positionCount = 0;
    
            while (true)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
            
                AddPointPosition(pos, positionPoint);
    
                int positionCount = lineRenderer.positionCount;
                positionCount++;
                lineRenderer.positionCount = positionCount;
                lineRenderer.SetPosition(positionCount - 1, pos);
            
                yield return null;
            }
        }
    
        private void AddPointPosition(Vector3 pos, Vector3 positionPoint)
        {
            float sqrLen = Vector3.Distance(positionPoint, pos);
    
            if (Mathf.Round(sqrLen) == _stepDistance)
            {
                GameObject newGameObject = Instantiate(_pointPrefab, pos, Quaternion.identity, _parentPoint);
                _pointList.Add(newGameObject);
                positionPoint = pos;
            }
        }
    }
}
