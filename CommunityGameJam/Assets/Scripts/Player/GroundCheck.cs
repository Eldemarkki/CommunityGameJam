using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private string groundTag = "Ground";

    public GroundHitEvent groundHitEvent;

    private void Awake()
    {
        groundHitEvent = new GroundHitEvent();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(groundTag))
        {
            groundHitEvent?.Invoke(other);
        }
    }
}
