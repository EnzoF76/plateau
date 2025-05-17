using UnityEngine;

[System.Serializable]
public struct SerializableVector2Int
{
    public int x;
    public int y;

    public Vector2Int ToVector2Int() => new Vector2Int(x, y);
}