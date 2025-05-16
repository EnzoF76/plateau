using UnityEngine;
using System.Collections.Generic;

public class GameInitializer : MonoBehaviour
{
    public GameConfig config;

    public GameObject playerPrefab;
    public TurnManager turnManager;

    const int maxPlayers = 4;

    private Vector2Int[] spawnPositions = new Vector2Int[]
    {
        new Vector2Int(0, 0),
        new Vector2Int(8, 0),
        new Vector2Int(0, 8),
        new Vector2Int(8, 8)
    };

    private Color[] playerColors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow
    };

    private void Start()
    {
        List<PlayerController> players = new List<PlayerController>();

        for (int i = 0; i < maxPlayers; i++)
        {
            GameObject playerObject = Instantiate(playerPrefab);
            PlayerController playerController = playerObject.GetComponent<PlayerController>();
            playerController.playerIndex = i;
            playerController.config = config;
            playerController.MoveTo(spawnPositions[i]);
            playerController.SetColor(playerColors[i]);
            playerObject.name = $"Player {i + 1}";
            players.Add(playerController);
        }

        turnManager.Initialize(players);
    }
}
