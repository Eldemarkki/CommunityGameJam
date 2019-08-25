using UnityEngine;

public class Picker : MonoBehaviour
{
    [SerializeField] private LayerMask pickupableLayer;
    [SerializeField] private Transform itemHolder;
    [SerializeField] private float pickupRadius;

    private Transform carriedItem;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (carriedItem != null)
            {
                // Carrying something
                DropItem();
            }
            else
            {
                // Not carrying anything
                Collider2D hit = Physics2D.OverlapCircle(itemHolder.position, pickupRadius, pickupableLayer);
                if (hit != null && hit.CompareTag("Pickupable"))
                {
                    PickupItem(hit.transform);
                }
            }
        }
    }

    void PickupItem(Transform item)
    {
        carriedItem = item;

        carriedItem.localRotation = Quaternion.identity;
        carriedItem.position = itemHolder.position;
        carriedItem.SetParent(itemHolder);
    }

    void DropItem()
    {
        carriedItem.parent = null;
        carriedItem = null;
    }
}
