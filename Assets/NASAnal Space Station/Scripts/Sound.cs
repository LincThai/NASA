namespace NASAnalSpaceStation
{
    using UnityEngine;
    using UnityEngine.Audio;

    [System.Serializable]
    public class Sound
    {
        // name variable
        public string name;

        // audioclip 
        public AudioClip clip;

        // volume
        [Range(0f, 1f)]
        public float volume;

        // pitch
        [Range(.1f, 3f)]
        public float pitch;

        // loop
        public bool loop;

        // AudioSource component
        [HideInInspector]
        public AudioSource source;

        public AudioMixerGroup mixerGroup;
    }
}