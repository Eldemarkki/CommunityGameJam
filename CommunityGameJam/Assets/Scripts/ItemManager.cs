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
        var itemNames = PlayerPrefs.GetString("unlockedItems", "").Split(';');

        for (int i = 0; i < itemNames.Length; i++)
        {
            Item item = GetItemByName(itemNames[i]);
            if (item)
            {
                unlockedItems.Add(item);
            }
        }

        unlockedItems = unlockedItems.OrderBy(i => i.name).ToList();
    }

    private Item GetItemByName(string itemName)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Item item = items[i];
            if (item.name == itemName)
            {
                return item;
            }
        }

        return null;
    }

    public Item GetRandomItem()
    {
        return items[Random.Range(0, items.Length)];
    }

    public void UnlockItem(Item item){
        if(item != null && unlockedItems.Contains(item))
            return;

        unlockedItems.Add(item);
        PlayerPrefs.SetString("unlockedItems", PlayerPrefs.GetString("unlockedItems", "") + ";" + item.name);
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
