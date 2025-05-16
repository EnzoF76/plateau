using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameConfig config;

    public int playerIndex;
    public Vector2Int gridPosition;

    private bool isMoving = false;
    
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

    public void MoveTo(Vector2Int newPosition, System.Action onMoveComplete = null)
    {
        if (isMoving) return;

        gridPosition = newPosition;

        float spacing = config != null ? config.tileSpacing : 0.0f;
        float tileHeight = config != null ? config.tileHeight : 0.0f;
        float pawnHeight = config != null ? config.playerHeight : 0.0f;

        float yOffset = tileHeight / 2f + pawnHeight / 2f;

        Vector3 targetPosition = new Vector3(
            newPosition.x * spacing, 
            yOffset, 
            newPosition.y * spacing
        );

        StopAllCoroutines();
        StartCoroutine(MoveSmoothly(targetPosition, onMoveComplete));
    }

    private IEnumerator MoveSmoothly(Vector3 targetPosition, System.Action onComplete)
    {
        isMoving = true;

        float duration = 0.25f;
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;

        onComplete?.Invoke();
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
