using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private Toggle toggle;

    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        toggle.onValueChanged.AddListener(ToggleChanged);
    }

    private void ToggleChanged(bool value)
    {
        audioSource.mute = !value;
    }
}
