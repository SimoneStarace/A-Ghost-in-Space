using UnityEngine;
using TMPro;
/// <summary>
/// Takes care of all the UI in the game.
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the text component.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI _uiTextStory = null;
    
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
}