using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    // Direction vector to control the player's movement
    private Vector3 direction;
    // Gravity value applied to pull the player downward
    public float gravity = -9.8f;
    // The amount of force applied when the player flaps
    public float strength = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Call the AnimateSprite method repeatedly at 0.15-second intervals
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        // Resets the player position to the center of the screen
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        // Reset the movement direction to zero
        direction = Vector3.zero;
    }


    private void Update()
    {
        // Check for player input to make the character flap
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Applies an upward force to the player
            direction = Vector3.up * strength;
        }

        // Check for touch input (for mobile devices)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Applies an upward force when the screen is touched
                direction = Vector3.up * strength;
            }
        }

        // Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    // Called when the player collides with a trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player hit an obstacle
        if (other.gameObject.tag == "Obstacle")
        {
            // Trigger the Game Over state
            FindObjectOfType<GameManager>().GameOver();
        }
        // Check if the player passed through a scoring zone
        else if (other.gameObject.tag == "Scoring")
        {
            // Increase the player's score
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}

