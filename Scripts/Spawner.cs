using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    // The rate at which the pipes are spawned
    public float spawnRate = 1f;
    // Minimum vertical offset for randomizing the spawn position.
    public float minHeight = -1f;
    // Maximum vertical offset for randomizing the spawn position.
    public float maxHeight = 1f;

    private void OnEnable()
    {
        // Start repeatedly calling the Spawn method at a regular interval
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        // Stop all InvokeRepeating calls to prevent spawning when the Spawner is disabled.
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // Instantiate a new pipe at the current position of the Spawner
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        // Randomize the vertical position of the pipes
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
