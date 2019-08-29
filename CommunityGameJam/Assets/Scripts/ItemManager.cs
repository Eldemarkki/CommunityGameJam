using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public delegate void UnlockItemEvent(Item item);
    public UnlockItemEvent onItemUnlock;
    public Item[] items;

    public List<Item> unlockedItems;

    public Item GetRandomItem()
    {
        return items[Random.Range(0, items.Length)];
    }

    public void UnlockItem(Item item){
        if(item != null && unlockedItems.Contains(item))
            return;

        unlockedItems.Add(item);
        onItemUnlock.Invoke(item);

        if(item.recipe1 != null && unlockedItems.Contains(item.recipe1)){
            UnlockItem(item.recipe1);
        }

        if(item.recipe2 != null && unlockedItems.Contains(item.recipe2)){
            UnlockItem(item.recipe2);
        }
    }
}
