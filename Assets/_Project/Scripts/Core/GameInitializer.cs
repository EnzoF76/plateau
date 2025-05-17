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
        new Vector2Int(1, 0),
        new Vector2Int(8, 1),
        new Vector2Int(0, 7),
        new Vector2Int(7, 8)
    };

    private Color[] playerColors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow
    };

    private string[] names = new string[]
    {
        "Yord",
        "Deytchi",
        "Neymios",
        "Gyude"
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
            playerController.SetName(names[i]);
            playerObject.name = names[i];
            players.Add(playerController);
        }

        turnManager.Initialize(players);

        GridManager.Instance.OnGridGenerated += () =>
        {
            GridManager.Instance.HighlightTilesForPlayer(turnManager.CurrentPlayer.gridPosition);
        };
    }
}
