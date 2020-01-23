using System.Collections;
using UnityEngine;
using TMPro;
namespace Managers
{
    /// <summary>
    /// Takes care of all the UI in the game.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        #region FIELDS
        /// <summary>
        /// Reference that tells if a sentence should be display immediatly or slowly.
        /// </summary>
        private bool _showTextImmediatly = false;
        /// <summary>
        /// Reference to the TextMeshPro component.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI _uiTextStory = null,
                                _uiCompanyText = null,
                                _uiVersionText = null;
        /// <summary>
        /// Reference to the quit button.
        /// </summary>
        [SerializeField]
        private UnityEngine.UI.Button _quitButton = null;
        /// <summary>
        /// Reference to a coroutine.
        /// </summary>
        private Coroutine _textCoroutine;
        #endregion

#if UNITY_WEBGL
        private void Awake()
        {
            //If the quit button is not null.
            if (_quitButton)
            {
                //Make the quit button not interactable.
                _quitButton.interactable = false;
            }
        }
#endif

    #region METHODS
    private void Start()
        {
            if (_uiCompanyText)
            {
                _uiCompanyText.text = $"Made by {ApplicationManager.GetCompanyName()}.";
            }

            if (_uiVersionText)
            {
                _uiVersionText.text = $"Version: {ApplicationManager.GetVersion()}";
            }
        }

        /// <summary>
        /// Update the text component.
        /// </summary>
        /// <param name="text">Text to change in the component.</param>
        public void UpdateStoryText(string text)
        {
            if (_uiTextStory)
            {
                //If the coroutine is not null
                if (_textCoroutine != null)
                {
                    //Stop the coroutine.
                    StopCoroutine(_textCoroutine);
                }
                //If the text should be shown slowly.
                if (!_showTextImmediatly)
                {
                    //Empty the text story
                    _uiTextStory.text = string.Empty;
                    //Show the dialogue in the text dialogue.
                    _textCoroutine = StartCoroutine(ShowTextDialogue(text));
                }
                else //Else assing all the text directly to the ui component.
                {
                    _uiTextStory.text = text;
                }
            }
        }
        /// <summary>
        /// Sets the flag of the member field.
        /// </summary>
        /// <param name="flag"></param>
        public void SetShowTextImmediatly(bool flag) => _showTextImmediatly = flag;
        /// <summary>
        /// Method to close the game when the quit button is pressed.
        /// </summary>
        public void OnQuitButtonPressed() => ApplicationManager.CloseApplication();
        /// <summary>
        /// Takes an url for open a webpage.
        /// </summary>
        /// <param name="url">The url of the webpage.</param>
        public void OpenWebPageByUrl(string url) => ApplicationManager.OpenWebPage(url);
        #endregion

        #region COROUTINES
        /// <summary>
        /// Coroutine to show the text.
        /// </summary>
        /// <param name="text">The text to show.</param>
        /// <returns></returns>
        private IEnumerator ShowTextDialogue(string text)
        {
            //For each character in the sentence
            foreach (char character in text.ToCharArray())
            {
                //Add the characyer in the sentence.
                _uiTextStory.text += character;
                //Wait
                yield return new WaitForEndOfFrame();
            }
        } 
        #endregion
    } 
}