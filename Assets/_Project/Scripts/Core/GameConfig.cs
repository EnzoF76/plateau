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
}
