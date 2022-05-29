namespace NASAnalSpaceStation
{
    using System;
    using UnityEngine;
    using UnityEngine.Audio;

    public class AudioManager : MonoBehaviour
    {
        #region Fields

        // set array
        public Sound[] sounds;

        // audioManager instance variable
        public static AudioManager instance;

        #endregion

        #region Unity Methods

        void Awake()
        {
            // checks for a second audiomanager game object
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            // does not destrouy object when loading new scene
            DontDestroyOnLoad(gameObject);

            // for each sound in the sound array do the following
            foreach (Sound s in sounds)
            {
                // assign to the source, the audiosource added to game object
                s.source = gameObject.AddComponent<AudioSource>();
                // assign the clip in the sound class to teh clip on the audiosource
                s.source.clip = s.clip;

                // assign the pitch and volume in the audiosource the valu in the sound class
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;

                // assign value of loop in the audiosource with loop from sound class
                s.source.loop = s.loop;
            }
        }

        void Start()
        {
            //Play();
        }

        #endregion

        #region Methods

        public void Play(string name)
        {
            // assign to s a sound with the same name, that was given to the function
            Sound s = Array.Find(sounds, sound => sound.name == name);

            // check if s is equal to null
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }    

            // play sound
            s.source.Play();
        }

        #endregion
    }
}