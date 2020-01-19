using System.Collections;
using UnityEngine;
using TMPro;
/// <summary>
/// Takes care of all the UI in the game.
/// </summary>
public class UIManager : MonoBehaviour
{
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

    private Coroutine _textCoroutine;

    private void Start()
    {
        if(_uiCompanyText)
        {
            _uiCompanyText.text = $"Made by {ApplicationManager.GetCompanyName()}.";
        }

        if(_uiVersionText)
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
        if(_uiTextStory)
        {
            //Stop any coroutine in execution
            StopCoroutine(_textCoroutine);
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
    /// Coroutine to show the text.
    /// </summary>
    /// <param name="text">The text to show.</param>
    /// <returns></returns>
    private IEnumerator ShowTextDialogue(string text)
    {
        //For each character in the sentence
        foreach(char character in text.ToCharArray())
        {
            //Add the characyer in the sentence.
            _uiTextStory.text += character;
            //Wait
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// Takes an url for open a webpage.
    /// </summary>
    /// <param name="url">The url of the webpage.</param>
    public void OpenWebPageByUrl(string url) => ApplicationManager.OpenWebPage(url);
    /// <summary>
    /// Sets the flag of the member field.
    /// </summary>
    /// <param name="flag"></param>
    public void SetShowTextImmediatly(bool flag) => _showTextImmediatly = flag;
}