using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderPanel : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform contentParent;
    [SerializeField] private ItemCreator itemCreator;
    [SerializeField] private ItemManager itemManager;

    private void Awake()
    {
        itemManager.onItemUnlock += AddItemToList;
        foreach(Item item in itemManager.unlockedItems){
            AddItemToList(item);
        }
    }

    private void AddItemToList(Item item)
    {
        Button button = Instantiate(buttonPrefab, contentParent).GetComponent<Button>();
        button.onClick.AddListener(() => CreateItem(item));

        button.GetComponentInChildren<TMP_Text>().text = item.name;
        button.GetComponentsInChildren<Image>()[1].sprite = item.icon;
    }

    private void CreateItem(Item item)
    {
        SoundManager.instance.Play("CreateItem");
        itemCreator.InstantiateItem(item, itemCreator.transform.position);
    }
}
