using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static CardDatabase Instance;

    public List<CardData> allCards;

    private void Awake()
    {
        Instance = this;

        // Chargements des cartes depuis le dossier Ressources/Cards
        allCards = new List<CardData>(Resources.LoadAll<CardData>("Cards"));
    }

    public CardData GetRandomCard()
    {
        int index = Random.Range(0, allCards.Count);

        return allCards[index];
    }
}
