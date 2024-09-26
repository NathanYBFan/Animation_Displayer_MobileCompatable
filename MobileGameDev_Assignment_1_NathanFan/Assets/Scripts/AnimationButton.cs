using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class AnimationButton : MonoBehaviour
{
    // UI elements
    private Button playButton;
    private TextMeshProUGUI textBox;

    // Animation State
    private enums.buttonStates currentState;

    private void Start()
    {
        currentState = enums.buttonStates.paused;
        playButton = GetComponent<Button>();
        textBox = GetComponentInChildren<TextMeshProUGUI>();

        playButton.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        // set correct current state
        currentState = currentState == 0 ? enums.buttonStates.paused : enums.buttonStates.playing;
        textBox.text = currentState == 0 ? "Pause" : "Play";

        AnimationController.Instance.SetAnimationState(currentState);
    }
}