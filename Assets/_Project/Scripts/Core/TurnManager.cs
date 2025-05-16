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

    public void EndTurn()
    {
        foreach (var player in players)
            player.SetActiveHighlight(false);

        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

        CurrentPlayer.SetActiveHighlight(true);
    }

    public void TryMoveTo(Vector2Int targetPosition) 
    {
        PlayerController player = CurrentPlayer;

        //if (Vector2Int.Distance(player.gridPosition, targetPosition) <= 1.1f)
        //{
            player.MoveTo(targetPosition, EndTurn);
        //}
    }
}
