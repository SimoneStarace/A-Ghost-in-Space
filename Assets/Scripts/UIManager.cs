using UnityEngine;
using TMPro;
/// <summary>
/// Takes care of all the UI in the game.
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the TextMeshPro component.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI _uiTextStory = null,
                            _uiVersionText = null;

    private void Start()
    {
        if(_uiVersionText)
        {
            _uiVersionText.text = "Version: " + ApplicationManager.GetVersion();
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
            _uiTextStory.text = text;
        }
    }

    /// <summary>
    /// Takes an url for open a webpage.
    /// </summary>
    /// <param name="url">The url of the webpage.</param>
    public void OpenWebPageByUrl(string url) => ApplicationManager.OpenWebPage(url);
}