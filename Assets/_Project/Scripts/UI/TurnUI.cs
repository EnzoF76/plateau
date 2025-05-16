using UnityEngine;
using TMPro;

public class TurnUI : MonoBehaviour
{
    public TMP_Text turnText;

    private void Update()
    {
        if (TurnManager.Instance != null && TurnManager.Instance.CurrentPlayer != null)
        {
            int index = TurnManager.Instance.CurrentPlayer.playerIndex + 1;
            turnText.text = $"Tour du Joueur {index}";
        }
    }
}
