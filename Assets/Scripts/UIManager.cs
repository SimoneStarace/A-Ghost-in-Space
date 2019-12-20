using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _storyText;
    // Start is called before the first frame update
    void Start()
    {
        if(_storyText)
        {
            _storyText.text = "Hello World!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}