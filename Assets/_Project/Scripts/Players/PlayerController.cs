using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameConfig config;

    public int playerIndex;
    public Vector2Int gridPosition;

    public TMP_Text nameText;

    private Renderer renderer;
    private Material instanceMaterial;

    public Color playerColor;
    public Color activeGlowColor = Color.white;

    void Start()
    {
        if (nameText != null)
        {
            nameText.text = $"Joueur {playerIndex + 1}";
        }
    }

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
        renderer = GetComponent<Renderer>();

        instanceMaterial = renderer.material;
        instanceMaterial.color = color;
        playerColor = color;

        renderer.material = instanceMaterial;
    }

    public void SetActiveHighlight(bool active) 
    {
        if (instanceMaterial != null)
        {
            if (active)
            {
                instanceMaterial.EnableKeyword("_EMISSION");
                instanceMaterial.SetColor("_EmissionColor", playerColor * 3f);
            }
            else
            {
                instanceMaterial.DisableKeyword("_EMISSION");
            }
        }
    }
}
