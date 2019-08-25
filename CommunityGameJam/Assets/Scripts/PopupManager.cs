using System.Collections;
using TMPro;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private TMP_Text popupText;

    public void ShowPopup(string text, float time){
        StartCoroutine(Show(text, time));
    }

    IEnumerator Show(string text, float time)
    {
        popupText.text = text;
        popupText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(time);
        popupText.gameObject.SetActive(false);
    }
}
