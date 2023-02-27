using System;
using Levels.Common;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioBackground;

        public AudioSource AudioBackground
        {
            get => audioBackground;
            set => audioBackground = value;
        }
    }
}
