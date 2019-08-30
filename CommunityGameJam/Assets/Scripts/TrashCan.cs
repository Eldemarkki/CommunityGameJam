using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] private Picker picker;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickupable"))
        {
            Pickupable pickupable = other.GetComponent<Pickupable>();
            if (pickupable == picker.carriedItem)
            {
                picker.DropItem();
            }

            SoundManager.instance.Play("TrashCan");
            Destroy(pickupable.gameObject);
        }
    }
}
