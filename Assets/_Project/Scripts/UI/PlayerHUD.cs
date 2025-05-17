using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHUD : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text manaText;
    public Transform handContainer;
    public GameObject cardUIPrefab;

    public void UpdateHUD(PlayerController player)
    {
        playerNameText.text = player.playerName;
        manaText.text = player.currentMana + " / " + player.maxMana;

        // Supprimer les cartes existantes (visuellement)
        foreach (Transform child in handContainer)
        {
            Destroy(child.gameObject);
        }

        // Créer de nouveaux éléments UI pour chaque carte dans la main du joueur
        foreach (var card in player.hand)
        {
            GameObject cardUI = Instantiate(cardUIPrefab, handContainer);

            var nameText = cardUI.transform.Find("CardName")?.GetComponent<TMP_Text>();
            var descText = cardUI.transform.Find("CardDescription")?.GetComponent<TMP_Text>();

            if (nameText != null)
            {
                nameText.text = card.data.name;
            }

            if (descText != null)
            {
                descText.text = card.data.description;
            }
        }
    }
}
