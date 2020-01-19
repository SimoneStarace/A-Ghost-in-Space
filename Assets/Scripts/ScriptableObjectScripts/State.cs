using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class that represent the State of the story.
/// </summary>
[CreateAssetMenu(fileName = "State")]
public class State : ScriptableObject
{
    /// <summary>
    /// The story text inside the state.
    /// </summary>
    [SerializeField,TextArea(10,14)]
    private string _storyText = null;
    /// <summary>
    /// List of states.
    /// </summary>
    [SerializeField]
    List<State> _states = new List<State>();

    /// <summary>
    /// Get the story text from the State.
    /// </summary>
    /// <returns></returns>
    public string GetStoryText()
    {
        return _storyText;
    }
    /// <summary>
    /// Get a State through a index
    /// </summary>
    /// <param name="index">Index of the state</param>
    /// <returns>The State</returns>
    public State GetStateByIndex(int index)
    {
        //If the index is lower than the number of states in the list.
        if(index < _states.Count)
        {
            // Return the state
            return _states[index];
        }
        //Return null if there aren't any state.
        return null;
    }
}