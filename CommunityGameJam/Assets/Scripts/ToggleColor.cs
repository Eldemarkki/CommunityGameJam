using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleColor : MonoBehaviour
{
    [SerializeField] private Color onColor;
    [SerializeField] private Color offColor;

    private Toggle toggle;

    private void Awake() {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnValueChanged);
        toggle.image.color = toggle.isOn ? onColor : offColor;
    }

    private void OnValueChanged(bool value)
    {
        toggle.image.color = value ? onColor : offColor;
    }
}
