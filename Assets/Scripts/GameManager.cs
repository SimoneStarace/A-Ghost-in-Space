using UnityEngine;

/// <summary>
/// Takes in control of all the game.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the UI Manager.
    /// </summary>
    private UIManager _uiManager;

    /// <summary>
    /// State of the story to display.
    /// </summary>
    [SerializeField]
    private State _actualState = null;

    void Awake()
    {
        if(_uiManager = GameObject.FindObjectOfType<UIManager>())
        {
#if UNITY_EDITOR
            Debug.Log("UI Manager found!");
#endif
            _uiManager.UpdateStoryText(_actualState ? _actualState.GetStoryText() : string.Empty);
        }
    }

    private void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        for(byte i = 0;i<9;i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1+i))
            {
#if UNITY_EDITOR
                Debug.Log("Input " + (KeyCode.Alpha1+i) + " has been pressed.");
#endif
                //Get the state from the list.
                State s;
                //Check if the State is not null
                if(s = _actualState.GetStateByIndex(i))
                {
                    //Update the state
                    _actualState = s;
                    //Update the text in the UI Manager.
                    _uiManager.UpdateStoryText(_actualState.GetStoryText());
                }
            }
        }
    }
}
