using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public delegate void UnlockItemEvent(Item item);
    public UnlockItemEvent onItemUnlock;
    public Item[] items;

    public List<Item> unlockedItems;

    private void Awake()
    {
        unlockedItems = unlockedItems.OrderBy(i => i.name).ToList();
    }

    public Item GetRandomItem()
    {
        return items[Random.Range(0, items.Length)];
    }

    public void UnlockItem(Item item){
        if(item != null && unlockedItems.Contains(item))
            return;

        unlockedItems.Add(item);
        unlockedItems = unlockedItems.OrderBy(i => i.name).ToList();

        onItemUnlock.Invoke(item);

        if(item.recipe1 != null && unlockedItems.Contains(item.recipe1)){
            UnlockItem(item.recipe1);
        }

        if(item.recipe2 != null && unlockedItems.Contains(item.recipe2)){
            UnlockItem(item.recipe2);
        }
    }
}
