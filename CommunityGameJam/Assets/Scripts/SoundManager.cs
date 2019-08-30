using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public SoundEffect[] sounds;

    private AudioSource source;

    public static SoundManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();
    }

    public void Play(string soundName)
    {
        SoundEffect sound = sounds.First(s => s.name == soundName);

        source.pitch = 1;
        source.PlayOneShot(sound.clip, sound.volume);
    }

    public void Play(string soundName, float minPitch, float maxPitch)
    {
        SoundEffect sound = sounds.First(s => s.name == soundName);

        source.pitch = Random.Range(minPitch, maxPitch);
        source.PlayOneShot(sound.clip, sound.volume);
    }
}
