using UnityEngine;
using UnityEngine.UI;

public sealed class AnimationController : MonoBehaviour
{
    #region Variables
    // Instance
    public static AnimationController Instance;

    // List of animation sprites
    [SerializeField] private Sprite[] animationSprites;

    // Animation settings
    [Range(0, 1)] private float animationPlaySpeed = 1f; // Clamp variable between 0 and 1 inclusive

    [SerializeField] private Image animationSprite;

    private bool animationIsPlaying = false;
    private int animationCount = 0;

    private float timer;
    [SerializeField] private float timerMax = 0.02f;
    #endregion

    #region Singleton Setup
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else if (Instance == null)
            Instance = this;
    }
    #endregion

    private void Start()
    {
        animationIsPlaying = false;
        animationPlaySpeed = 1f; // 1 is normal speed, 0 is stopped
        timer = 0f;

        animationCount = 0;
        animationSprite.sprite = animationSprites[animationCount];
    }

    private void Update()
    {
        // If play animation is off or animation play speed is at 0
        if (!animationIsPlaying || animationPlaySpeed == 0) return;

        // Increment Variables
        timer += Time.deltaTime;

        // Timer check
        if (timer <= timerMax / animationPlaySpeed) return;
        // Reset timer
        timer = 0f;

        animationCount++;

        // Value error checks
        if (animationCount > animationSprites.Length - 1) animationCount = 0;
        else if (animationCount < 0) animationCount = animationSprites.Length - 1;

        // Set sprite
        animationSprite.sprite = animationSprites[animationCount];
    }

    public void SetAnimationState(enums.buttonStates buttonState)
    {
        animationIsPlaying = buttonState == 0 ? true : false;
    }

    public void SetAnimationSpeed(float newSpeed)
    {
        // Make sure inputted variable is viable
        newSpeed = newSpeed > 1 ? newSpeed % 1 : newSpeed; // should error check be here or on recieve

        animationPlaySpeed = newSpeed;
    }
}