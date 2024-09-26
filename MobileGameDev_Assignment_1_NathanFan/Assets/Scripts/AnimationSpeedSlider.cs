using UnityEngine;
using UnityEngine.UI;

public sealed class AnimationSpeedSlider : MonoBehaviour
{
    [SerializeField] private AnimationController animController;

    private Slider speedSlider;

    [Range(0, 1)] private float speed;

    void Start()
    {
        speedSlider = GetComponent<Slider>();

        speedSlider.onValueChanged.AddListener(OnSpeedChanged);
    }

    private void OnSpeedChanged(float newSpeed)
    {
        animController.SetAnimationSpeed(newSpeed);
    }
}
