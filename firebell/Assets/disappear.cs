using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button button;

    void Start()
    {
        // Get a reference to the Button component
        button = GetComponent<Button>();

        // Add a click event listener to the button
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // Disable the button game object to make it disappear
        button.gameObject.SetActive(false);
    }
}
