using UnityEngine;

public class Combiner : MonoBehaviour
{
    [SerializeField] private CombineSpot combineSpot1, combineSpot2;
    [SerializeField] private Transform outputSpot;
    [SerializeField] private ItemCreator itemCreator;
    [SerializeField] private PopupManager popupManager;
    [SerializeField] private ItemManager itemManager;

    public void TryCombine()
    {
        Pickupable item1 = combineSpot1.GetItem();
        Pickupable item2 = combineSpot2.GetItem();

        if (item1 && item2)
        {
            Combine(item1, item2);
        }
    }

    private void Combine(Pickupable item1, Pickupable item2)
    {
        Item newItem = GetCombination(item1.item, item2.item);
        if (newItem)
        {
            Destroy(item1.gameObject);
            Destroy(item2.gameObject);

            itemCreator.InstantiateItem(newItem, outputSpot.position);
        }
        else
        {
            popupManager.ShowPopup("That doesn't seem to be a recipe", 2f);
        }
    }

    private Item GetCombination(Item item1, Item item2)
    {
        foreach (Item item in itemManager.items)
        {
            if (CanCombine(item, item1, item2))
            {
                return item;
            }
        }

        return null;
    }

    private bool CanCombine(Item target, Item item1, Item item2)
    {
        return (target.recipe1 == item1 && target.recipe2 == item2) ||
               (target.recipe1 == item2 && target.recipe2 == item1);
    }
}
