using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Tile : MonoBehaviour
{
    private Color originalColor;
    private Renderer renderer;

    public Color hoverColor = new Color32(235, 204, 255, 255);

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    private void OnMouseEnter()
    {
        renderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        renderer.material.color = originalColor;
    }
}
