using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class that represent the State of the story.
/// </summary>
[CreateAssetMenu(fileName = "State")]
public class State : ScriptableObject
{
    #region FIELDS
    /// <summary>
    /// The story text inside the state.
    /// </summary>
    [SerializeField, TextArea(10, 14)]
    private string _storyText = null;
    /// <summary>
    /// The music clip to play when the states is taken.
    /// </summary>
    [SerializeField]
    private AudioClip _musicClip = null;

    /// <summary>
    /// List of states.
    /// </summary>
    [SerializeField]
    List<State> _states = new List<State>();
    #endregion

    #region METHODS
    /// <summary>
    /// Get the story text from the State.
    /// </summary>
    /// <returns></returns>
    public string GetStoryText() => _storyText;
    /// <summary>
    /// Gets the reference to the Music Clip.
    /// </summary>
    /// <returns>The Music clip.</returns>
    public AudioClip GetMusicClip() => _musicClip;
    /// <summary>
    /// Get a State through a index
    /// </summary>
    /// <param name="index">Index of the state</param>
    /// <returns>The State</returns>
    public State GetStateByIndex(int index)
    {
        //If the index is lower than the number of states in the list.
        if (index < _states.Count)
        {
            // Return the state
            return _states[index];
        }
        //Return null if there aren't any state.
        return null;
    } 
    #endregion
}