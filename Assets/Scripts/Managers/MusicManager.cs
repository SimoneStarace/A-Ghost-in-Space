using UnityEngine;
namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviour
    {
        #region FIELDS
        /// <summary>
        /// Reference to the Audio Source.
        /// </summary>
        private AudioSource _audioSource;
        /// <summary>
        /// Option for tell if the music must be played.
        /// </summary>
        private bool _isMusicOn = true; 
        #endregion

        #region METHODS
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        /// <summary>
        /// Checks if the music should be played.
        /// </summary>
        /// <param name="flag"></param>
        public void SetIsMusicOn(bool flag = true)
        {
            //Set the flag.
            _isMusicOn = flag;
            //Play or stop the music.
            PlayStopMusicClip();
        }
        /// <summary>
        /// Method for set the Music
        /// </summary>
        /// <param name="clip">The music clip.</param>
        public void SetMusicClip(AudioClip clip)
        {
            //if the clip is not null and it's different from the audiosource clip.
            if(clip && clip != _audioSource.clip)
            {
                //Update the clip.
                _audioSource.clip = clip;
                //Play the music.
                PlayStopMusicClip();
            }
        }
        /// <summary>
        /// Method for play or stop the audio clip.
        /// </summary>
        private void PlayStopMusicClip()
        {
            //If the flag is true and the audioclip is not null.
            if(_isMusicOn && _audioSource.clip)
            {
                //Play the music.
                _audioSource.Play();
            }
            else //else stop the music.
            {
                _audioSource.Stop();
            }
        }
        #endregion
    } 
}