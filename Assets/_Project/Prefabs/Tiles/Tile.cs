using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Tile : MonoBehaviour
{
    private Renderer renderer;

    private Vector2Int gridPos;
    private Color originalColor;
    public Color hoverColor = new Color32(235, 204, 255, 255);

    private void Start()
    {
        renderer = GetComponent<Renderer>();

        string[] parts = name.Replace("Tile_", "").Split('_');
        int x = int.Parse(parts[0]);
        int y = int.Parse(parts[1]);
        gridPos = new Vector2Int(x, y);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on tile at : " + gridPos);
        TurnManager.Instance.TryMoveTo(gridPos);
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