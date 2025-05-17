using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }

    public List<PlayerController> players;
    private int currentPlayerIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Initialize(List<PlayerController> playerList)
    {
        players = playerList;
        currentPlayerIndex = 0;

        CurrentPlayer.SetActiveHighlight(true);
    }

    public PlayerController CurrentPlayer => players[currentPlayerIndex];

    public List<PlayerController> Players => players;

    public void EndTurn()
    {
        foreach (var player in players)
            player.SetActiveHighlight(false);

        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

        CurrentPlayer.SetActiveHighlight(true);

        GridManager.Instance.HighlightTilesForPlayer(CurrentPlayer.gridPosition);
    }

    public void TryMoveTo(Vector2Int targetPosition) 
    {
        PlayerController player = CurrentPlayer;

        // On vérifie si la tuile cible est atteignable/accessible
        if (!GridManager.Instance.GetReachableTiles(player.gridPosition).Contains(targetPosition))
            return;

        player.MoveTo(targetPosition, EndTurn);
    }
}
