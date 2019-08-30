using UnityEngine;

public class CombineSpot : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask pickupableMask;
    [SerializeField] private PopupManager popupManager;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public Pickupable GetItem()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, radius, pickupableMask);

        if (hits.Length > 1)
        {
            SoundManager.instance.Play("WrongAnswer");
            popupManager.ShowPopup("You can only have 1 item per combine spot!", 3f);

            return null;
        }

        if (hits.Length <= 0)
        {
            SoundManager.instance.Play("WrongAnswer");
            popupManager.ShowPopup("You need to have at least one item on the combine spot!", 3f);

            return null;
        }

        return hits[0].GetComponent<Pickupable>();
    }
}

