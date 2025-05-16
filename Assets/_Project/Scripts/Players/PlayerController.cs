using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameConfig config;

    public int playerIndex;
    public Vector2Int gridPosition;

    public void MoveTo(Vector2Int newPosition)
    {
        Debug.Log($"Déplacement joueur {playerIndex} vers {newPosition}");

        gridPosition = newPosition;
        float spacing = config != null ? config.tileSpacing : 2.0f;
        transform.position = new Vector3(newPosition.x * spacing, 0.5f, newPosition.y * spacing);
    }

    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
