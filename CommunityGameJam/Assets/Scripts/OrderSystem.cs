using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] GameObject itemPrefab;

    private Queue<Item> orders;

    private void Awake() {
        orders = new Queue<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            OrderItem(items[0]);
        }

        if(Input.GetKeyDown(KeyCode.T)){
            DeliverNextItem();
        }
    }

    void OrderItem(Item item){
        orders.Enqueue(item);
    }

    void DeliverNextItem(){
        Item item = orders.Dequeue();
        GameObject go = Instantiate(itemPrefab, Vector3.right * 3, Quaternion.identity);

        go.name = item.name;
        go.GetComponent<SpriteRenderer>().sprite = item.icon;
        go.GetComponent<Pickupable>().item = item;
    }
}
