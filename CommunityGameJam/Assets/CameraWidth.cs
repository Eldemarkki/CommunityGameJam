using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraWidth : MonoBehaviour
{
    [SerializeField] private float width = 10f;

    private Camera cam;

    private void OnValidate() {
        SetWidth(width);
    }

    private void Awake() {
        SetWidth(width);
    }

    private void SetWidth(float width){
        if(cam == null)
            cam = GetComponent<Camera>();
        
        cam.orthographicSize = width / cam.aspect;
    }
}
