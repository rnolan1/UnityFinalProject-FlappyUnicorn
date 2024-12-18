using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Reference to the Player script for enabling/disabling the player
    public Player player;
    // UI Text component to display the current score
    public Text scoreText;
    // GameObject representing the "Play" button in the UI
    public GameObject playButton;
    // GameObject representing the "Game Over" UI screen
    public GameObject gameOver;
    // Private variable to keep track of the player's score
    private int score;

    // Called when the GameManager is initialized
    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Pause()
    {
        // Stop all time-based actions in the game
        Time.timeScale = 0f;
        // Disable player movement/input when paused
        player.enabled = false;
    }

    // Method to start or resume the game
    public void Play()
    {
        // Reset the score to zero and update the score display
        score = 0;
        scoreText.text = score.ToString();

        // Hide the Play button and Game Over screen
        playButton.SetActive(false);
        gameOver.SetActive(false);

        // Resume time-based actions in the game
        Time.timeScale = 1f;
        // Enable player movement/input
        player.enabled = true;

        // Find and destroy any remaining pipes in the scene
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    // Method to trigger the Game Over state
    public void GameOver()
    {

        // Display the Game Over screen and the Play button
        gameOver.SetActive(true);
        playButton.SetActive(true);

        // Pause the game to stop all movement and input
        Pause();
    }

    // Method to increase the player's score
    public void IncreaseScore()
    {
        // Increment the score
        score++;
        // Update the score display in the UI
        scoreText.text = score.ToString();
    }

}
