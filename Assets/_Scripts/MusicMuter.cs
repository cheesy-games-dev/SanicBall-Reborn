using System.Collections;
using Sanicball.Data;
using UnityEngine;

namespace Sanicball
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicMuter : EntityBehaviour
    {
        private AudioSource aSource;

        private void Start()
        {
            aSource = GetComponent<AudioSource>();
        }

        public override void OnUpdate()
        {
            aSource.mute = !ActiveData.GameSettings.music;
        }
    }
}
