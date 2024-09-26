using UnityEngine;
using UnityEngine.UI;

public sealed class AnimationSpeedSlider : MonoBehaviour
{
    // UI element
    private Slider speedSlider;

    void Start()
    {
        speedSlider = GetComponent<Slider>();

        speedSlider.onValueChanged.AddListener(OnSpeedChanged);
    }

    private void OnSpeedChanged(float newSpeed)
    {
        AnimationController.Instance.SetAnimationSpeed(newSpeed);
    }
}
