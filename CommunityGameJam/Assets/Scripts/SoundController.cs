using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public AudioMixer mixer;

    private float originalVolume = -80;

    public static SoundController instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void FlipMusic()
    {
        float currentVolume;
        mixer.GetFloat("musicVolume", out currentVolume);

        if (currentVolume == 0)
            mixer.SetFloat("musicVolume", originalVolume);
        else
            mixer.SetFloat("musicVolume", 0);

        mixer.GetFloat("musicVolume", out currentVolume);
        PlayerPrefs.SetFloat("musicVolume", currentVolume);
    }

    public void SetVolume(string target, float volume)
    {
        mixer.SetFloat(target, volume);
        PlayerPrefs.SetFloat(target, volume);
    }

    public void FlipSFX()
    {
        float currentVolume;
        mixer.GetFloat("sfxVolume", out currentVolume);

        if (currentVolume == 0)
            mixer.SetFloat("sfxVolume", 20);
        else
            mixer.SetFloat("sfxVolume", 0);

        mixer.GetFloat("sfxVolume", out currentVolume);
        PlayerPrefs.SetFloat("sfxVolume", currentVolume);
    }
}
