using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public int livesLeft = 3;
    [SerializeField] TMP_Text healthText;
    [SerializeField] Animator loseAnimator;

    public void ReduceHealth(int amount)
    {
        if (livesLeft - amount <= 0)
        {
            livesLeft = 0;
            GameOver();
        }
        else
        {
            livesLeft -= amount;
        }

        healthText.text = livesLeft.ToString();
    }

    private void GameOver()
    {
        PlayerPrefs.DeleteKey("unlockedItems");
        loseAnimator.SetTrigger("GameOver");
        StartCoroutine(GotoMenuAfter(3f));
    }

    private IEnumerator GotoMenuAfter(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        GotoMenu();
    }

    public void GotoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void SetPaused(bool paused)
    {
        Time.timeScale = paused ? 0 : 1;
        pausePanel.SetActive(paused);
    }

    public void PlayButtonSound(){
        SoundManager.instance.Play("ButtonClick");
    }
}
