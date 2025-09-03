using UnityEngine;

public class RandomPainter : MonoBehaviour
{
    private void Start()
    {
        Renderer objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.color = Random.ColorHSV();
    }
}
