using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    private Dictionary<Vector2Int, Tile> tiles = new Dictionary<Vector2Int, Tile>();

    public GameObject tilePrefab; // Prefab utilisé pour chaque tuile
    public GameConfig config;

    public event System.Action OnGridGenerated;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateGrid();
        CenterCamera();
        //ColorCorners();
    }

    void GenerateGrid()
    {
        for (int i = 0; i < config.gridWidth; i++)
        {
            for (int j = 0; j < config.gridHeight; j++)
            {
                // Position 3D de la tuile
                Vector3 position = new Vector3(i * config.tileSpacing, 0, j * config.tileSpacing);

                // Instanciation de la tuile à cette position (Quaternion=rotation)
                GameObject tileObj = Instantiate(tilePrefab, position, Quaternion.identity, transform);

                // Nom de la tuile pour faciliter le débug
                tileObj.name = $"Tile_{i}_{j}";

                Tile tile = tileObj.GetComponent<Tile>();
                tiles[new Vector2Int(i, j)] = tile;
            }
        }

        // Appel de l'événement après la génération de la grille
        OnGridGenerated?.Invoke();
    }

    void CenterCamera()
    {
        float centerX = (config.gridWidth - 1) * config.tileSpacing / 2f;
        float centerZ = (config.gridHeight - 1) * config.tileSpacing / 2f;
        
        Vector3 centerPoint = new Vector3(centerX, 0, centerZ);

        // Distance verticale de la caméra
        float cameraHeight = 20f;

        // Angle en radians pour la position correcte de la caméra
        float angleRadians = Mathf.Deg2Rad * 45f;

        // Position de la caméra pour regarder le centre depuis une diagonale
        Vector3 cameraOffset = new Vector3(-1, 0.6f, -1).normalized * cameraHeight;

        Camera.main.transform.position = centerPoint + cameraOffset;
        Camera.main.transform.LookAt(centerPoint);
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = Mathf.Max(config.gridWidth, config.gridHeight) * config.tileSpacing * 0.7f;
    }

    void ColorCorners()
    {
        Dictionary<Vector2Int, Color> cornerColors = new Dictionary<Vector2Int, Color>
        {
            { new Vector2Int(0, 0), new Color32(255, 173, 175, 255) },
            { new Vector2Int(config.gridWidth - 1, 0), new Color32(203, 255, 193, 255) },
            { new Vector2Int(0, config.gridHeight - 1), new Color32(161, 195, 255, 255) },
            { new Vector2Int(config.gridWidth - 1, config.gridHeight - 1), new Color32(253, 255, 182, 255) }
        };
        
        foreach (Transform child in transform)
        {
            string[] parts = child.name.Replace("Tile_", "").Split("_");
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            Vector2Int position = new Vector2Int(x, y);

            if (cornerColors.ContainsKey(position))
            {
                Renderer renderer = child.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = cornerColors[position];
                }
            }
        }
    }

    public void HighlightTilesForPlayer(Vector2Int origin)
    {
        ClearHighlights();

        Vector2Int[] directions =
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };

        foreach (var direction in directions)
        {
            Vector2Int targetPos = origin + direction;
            if (tiles.ContainsKey(targetPos))
            {
                tiles[targetPos].Highlight(true);
            }
        }
    }

    private void ClearHighlights()
    {
        foreach (var tile in tiles.Values)
        {
            tile.Highlight(false);
        }
    }
}
