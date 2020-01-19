using UnityEngine;
/// <summary>
/// Takes in control of all the game.
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Member fields
    /// <summary>
    /// Reference to the UI Manager.
    /// </summary>
    private UIManager _uiManager;

    /// <summary>
    /// State of the story to display.
    /// </summary>
    [SerializeField]
    private State _actualState = null;
    #endregion

    void Awake()
    {
        //Set the target framerate.
        ApplicationManager.SetFramerate();

        //Find the UI Manager
        if(_uiManager = FindObjectOfType<UIManager>())
        {
#if UNITY_EDITOR
            Debug.Log("GameManager: UI Manager found!");
#endif
            //Update the state of the game.
            _uiManager.UpdateStoryText(_actualState ? _actualState.GetStoryText() : string.Empty);
        }
    }

    private void Update()
    {
        ManageState();
    }
    /// <summary>
    /// Manage the state of the game.
    /// </summary>
    private void ManageState()
    {
        for(byte i = 0;i<9;i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1+i))
            {
#if UNITY_EDITOR
                Debug.Log("Input " + (KeyCode.Alpha1 + i) + " has been pressed.");
#endif
                UpdateState(i);
            }
        }
    }
    /// <summary>
    /// Update the state of the story.
    /// </summary>
    /// <param name="i">Index to search.</param>
    private void UpdateState(byte i)
    {
        //Get the state from the list.
        State s;
        //Check if the State is not null
        if (s = _actualState.GetStateByIndex(i))
        {
            //Update the state
            _actualState = s;
            //Update the text in the UI Manager.
            _uiManager.UpdateStoryText(_actualState.GetStoryText());
        }
    }
}