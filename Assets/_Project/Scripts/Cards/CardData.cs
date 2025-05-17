using UnityEngine;

public enum CardType
{
    Ground,
    Action
}

[CreateAssetMenu(fileName = "NewCard", menuName = "Game/Card")]
public class  CardData : ScriptableObject
{
    public string name;
    public CardType type;
    public Sprite icon;
    public int cost;

    [TextArea]
    public string description;
}
