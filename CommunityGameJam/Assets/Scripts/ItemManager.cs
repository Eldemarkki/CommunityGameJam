using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item[] items;

    public Item GetRandomItem()
    {
        return items[Random.Range(0, items.Length)];
    }
}
