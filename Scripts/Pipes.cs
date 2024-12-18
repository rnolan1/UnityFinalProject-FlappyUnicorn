using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Speed of the pipes moving to the left of the screen
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        // Calculate the position of the left edge of the screen
        // Subtract 1 unit so pipes are destroyed just slightly off-screen.
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        // Move the pipe to the left over time.
        transform.position += speed * Time.deltaTime * Vector3.left;

        // Check if the pipe has moved past the left edge of the screen
        if (transform.position.x < leftEdge)
        {
            // Destroys the pipe GameObject
            Destroy(gameObject);
        }
    }
}
