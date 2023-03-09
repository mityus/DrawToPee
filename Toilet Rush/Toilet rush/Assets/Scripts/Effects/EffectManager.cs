using System;
using UnityEngine;

namespace Effects
{
    public class EffectManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem failEffectPrefab;
        [SerializeField] private ParticleSystem winEffectPrefab;

        public ParticleSystem WinEffect { get => winEffectPrefab; }
        public ParticleSystem FailEffectPrefab => failEffectPrefab;

        public void PlayEffect(ParticleSystem effect, Transform go)
        {
            Vector3 goPosition = go.position;
            Vector3 goLocalScale = go.localScale;
            
            Instantiate(effect, 
                new Vector2(goPosition.x, goPosition.y + goLocalScale.y * 2), Quaternion.identity, 
                gameObject.transform);
        }
    }
}
