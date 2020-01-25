using UnityEngine;
namespace Managers
{
    /// <summary>
    /// Takes in control of all the game.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region FIELDS
        /// <summary>
        /// Reference to the UI Manager.
        /// </summary>
        private UIManager _uiManager;
        /// <summary>
        /// Reference to the Music Manager.
        /// </summary>
        private MusicManager _musicManager;
        /// <summary>
        /// State of the story to display.
        /// </summary>
        [SerializeField]
        private State _actualState = null;
        #endregion

        #region METHODS

        void Awake()
        {
            //Set the target framerate.
            ApplicationManager.SetFramerate();

            //Find the UI Manager
            if (_uiManager = FindObjectOfType<UIManager>())
            {
#if UNITY_EDITOR
                Debug.Log("GameManager: UI Manager found!");
#endif
                //Update the state of the game.
                _uiManager.UpdateStoryText(_actualState ? _actualState.GetStoryText() : string.Empty);
            }
            //Find the Music Manager.
            if(_musicManager = FindObjectOfType<MusicManager>())
            {
#if UNITY_EDITOR
                Debug.Log("GameManager: Music Manager found!");
#endif
                //Set the music for Music Manager.
                _musicManager.SetMusicClip(_actualState.GetMusicClip());
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
            for (byte i = 0; i < 9; i++)
            {
                //For each numerical button (from 0 to 9)
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
#if UNITY_EDITOR
                    Debug.Log("Input " + (KeyCode.Alpha1 + i) + " has been pressed.");
#endif
                    //Update the state using the index of the button.
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
                //if the UI Manager is not null.
                if (_uiManager)
                {
                    //Update the text in the UI Manager.
                    _uiManager.UpdateStoryText(_actualState.GetStoryText());
                }
                //If the music manager is not null
                if(_musicManager)
                {
                    //Update the Music.
                    _musicManager.SetMusicClip(s.GetMusicClip());
                }
            }
        } 
        #endregion
    } 
}