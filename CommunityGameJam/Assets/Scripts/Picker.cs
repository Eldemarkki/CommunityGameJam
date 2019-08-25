using System.Linq;
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
                Collider2D[] hits = Physics2D.OverlapCircleAll(itemHolder.position, pickupRadius, pickupableLayer);
                if (hits != null && hits.Any(h => h.CompareTag("Pickupable")))
                {
                    // Sort by distance and get the closest point
                    var hit = hits.OrderBy(h => Vector3.Distance(h.transform.position, transform.position)).First();
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
