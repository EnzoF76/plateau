using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Tile : MonoBehaviour
{
    private Renderer renderer;

    private Vector2Int gridPos;
    private Color originalColor;

    public Color hoverColor = new Color32(235, 204, 255, 255);

    private bool isHighlighted;
    public Color highlightColor = new Color32(188, 226, 185, 255);

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    private void Start()
    {
        string[] parts = name.Replace("Tile_", "").Split('_');
        int x = int.Parse(parts[0]);
        int y = int.Parse(parts[1]);
        gridPos = new Vector2Int(x, y);
    }

    private void OnMouseDown()
    {
        TurnManager.Instance.TryMoveTo(gridPos);
    }

    private void OnMouseEnter()
    {
        renderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        if (isHighlighted)
            renderer.material.color = highlightColor;
        else 
            renderer.material.color = originalColor;
    }

    public void Highlight(bool enable)
    {
        isHighlighted = enable;
        renderer.material.color = enable ? highlightColor : originalColor;
    }
}