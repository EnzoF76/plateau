using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game/GameConfig")]
public class GameConfig : ScriptableObject
{
    public int gridWidth = 9;
    public int gridHeight = 9;
    public float tileSpacing = 1.1f;

    public float tileHeight = 0.25f;
    public float playerHeight = 1.0f;

    [Header("Déplacements autorisés")]
    public SerializableVector2Int[] allowedDirections;

    private void OnEnable()
    {
        // Auto-remplissage si vide
        if (allowedDirections == null || allowedDirections.Length == 0)
        {
            allowedDirections = new SerializableVector2Int[]
            {
                new SerializableVector2Int { x = 0, y = 1 },  // haut
                new SerializableVector2Int { x = 0, y = -1 }, // bas
                new SerializableVector2Int { x = -1, y = 0 }, // gauche
                new SerializableVector2Int { x = 1, y = 0 }   // droite
            };
        }
    }
}
