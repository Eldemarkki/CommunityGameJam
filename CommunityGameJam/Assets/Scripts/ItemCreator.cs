using System.Collections;
using TMPro;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;

    public void InstantiateItem(Item item, Vector3 position, float time = 0)
    {
        StartCoroutine(InstantiateItemAfter(item, position, time));
    }

    IEnumerator InstantiateItemAfter(Item item, Vector3 position, float time)
    {
        yield return new WaitForSecondsRealtime(time);

        GameObject go = Instantiate(pickupPrefab, position, Quaternion.identity);

        go.name = item.name;
        go.GetComponent<SpriteRenderer>().sprite = item.icon;
        go.GetComponent<Pickupable>().item = item;
        go.GetComponentInChildren<TMP_Text>().text = item.name;
    }
}
