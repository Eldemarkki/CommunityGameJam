using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int livesLeft = 3;
    [SerializeField] TMP_Text healthText;
    [SerializeField] Animator loseAnimator;

    public void ReduceHealth(int amount){
        if(livesLeft - amount <= 0){
            livesLeft = 0;
            GameOver();
        }
        else {
            livesLeft -= amount;
        }

        healthText.text = livesLeft.ToString();
    }

    private void GameOver(){
        loseAnimator.SetTrigger("GameOver");
        StartCoroutine(GotoMenu(3f));
    }

    private IEnumerator GotoMenu(float time){
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene("Menu");
    }
}
