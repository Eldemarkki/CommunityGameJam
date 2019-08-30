using TMPro;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;

    public GameObject InstantiateItem(Item item, Vector3 position)
    {
        GameObject go = Instantiate(pickupPrefab, position, Quaternion.identity);

        go.name = item.name;
        go.GetComponent<SpriteRenderer>().sprite = item.icon;
        go.GetComponent<Pickupable>().item = item;
        go.GetComponentInChildren<TMP_Text>().text = item.name;

        return go;
    }
}
