using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameConfig config;

    public int playerIndex;
    public Vector2Int gridPosition;

    public void MoveTo(Vector2Int newPosition)
    {
        gridPosition = newPosition;

        float spacing = config != null ? config.tileSpacing : 0.0f;
        float tileHeight = config != null ? config.tileHeight : 0.0f;
        float pawnHeight = config != null ? config.playerHeight : 0.0f;

        float yOffset = tileHeight / 2f + pawnHeight / 2f;

        transform.position = new Vector3(
            newPosition.x * spacing, 
            yOffset, 
            newPosition.y * spacing
        );
    }

    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
