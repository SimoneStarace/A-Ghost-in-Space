using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the Audio Source.
    /// </summary>
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        PlayStopMusic();
    }
    /// <summary>
    /// Checks if the music should be played.
    /// </summary>
    /// <param name="flag"></param>
    public void PlayStopMusic(bool flag = true)
    {
        if(flag && _audioSource.clip)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
}