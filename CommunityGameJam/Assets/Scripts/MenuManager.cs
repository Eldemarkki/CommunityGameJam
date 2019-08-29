using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle sfxToggle;

    public static MenuManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("musicVolume", 0);
        musicToggle.SetIsOnWithoutNotify(musicVolume == 0);
        SoundController.instance.SetVolume("musicVolume", musicVolume);

        float sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 0);
        sfxToggle.SetIsOnWithoutNotify(sfxVolume == 0);
        SoundController.instance.SetVolume("sfxVolume", sfxVolume);
    }

    public void FlipMusic(){
        SoundController.instance.FlipMusic();
    }

    public void FlipSFX(){
        SoundController.instance.FlipSFX();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
