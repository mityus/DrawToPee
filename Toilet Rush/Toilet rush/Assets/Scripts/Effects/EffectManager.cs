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

            float positionY = effect.gameObject.name == "FightEffect" ? 
                goPosition.y + goLocalScale.y : goPosition.y + goLocalScale.y * 2.5f;

            Instantiate(effect, 
                new Vector2(goPosition.x, positionY), Quaternion.identity,
                    gameObject.transform);
        }
    }
}
