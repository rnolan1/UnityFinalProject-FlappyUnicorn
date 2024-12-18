using UnityEngine;

public class Parallax : MonoBehaviour
{
    // The speed at which the texture will scroll
    public float animationSpeed = 1f;
    private MeshRenderer meshRenderer;

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame.
    private void Update()
    {
        // Scroll the texture by modifying its offset over time.
        // The texture will move horizontally based on the animationSpeed and time elapsed.
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
