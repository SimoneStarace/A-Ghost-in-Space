using UnityEngine;
namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviour
    {
        /// <summary>
        /// Reference to the Audio Source.
        /// </summary>
        private AudioSource _audioSource;

        #region METHODS
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        /// <summary>
        /// Checks if the music should be played.
        /// </summary>
        /// <param name="flag"></param>
        public void PlayStopMusic(bool flag = true)
        {
            if (flag && _audioSource.clip)
            {
                _audioSource.Play();
            }
            else
            {
                _audioSource.Stop();
            }
        }
        /// <summary>
        /// Method for set the Music
        /// </summary>
        /// <param name="clip">The music clip.</param>
        public void SetMusic(AudioClip clip)
        {
            //if the clip is not null.
            if(clip)
            {
                //Update the clip.
                _audioSource.clip = clip;
                //Play the music.
                PlayStopMusic();
            }
        }
        #endregion
    } 
}