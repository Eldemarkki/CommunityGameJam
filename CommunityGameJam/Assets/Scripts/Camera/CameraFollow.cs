using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float damping;

    void Update()
    {
        Vector2 newPosition = Vector2.Lerp(transform.position, target.position, damping * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}
