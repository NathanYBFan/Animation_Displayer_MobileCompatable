using UnityEngine;

public sealed class AnimationController : MonoBehaviour
{
    [SerializeField] private Sprite[] animationSprites;

    private bool animationIsPlaying = false;

    [Range(0, 1)] private float animationPlaySpeed = 1f; // Clamp variable between 0 and 1 inclusive

    private void Start()
    {
        animationIsPlaying = false;
        animationPlaySpeed = 1f; // 1 is normal speed, 0 is stopped
    }

    private void Update()
    {
        if (!animationIsPlaying) return;
        // Timer?
        // 

    }

    public void SetAnimationState(enums.buttonStates buttonState)
    {
        animationIsPlaying = buttonState == 0 ? true : false;
    }

    public void SetAnimationSpeed(float newSpeed)
    {
        // Make sure inputted variable is viable
        newSpeed = newSpeed > 1 ? newSpeed % 1 : newSpeed;

        animationPlaySpeed = newSpeed;
    }
}
