using UnityEngine;

public class Plant : MonoBehaviour
{
    private Animator animator;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            SoundManager.instance.Play("ShakePlant");
            animator.SetTrigger("ShakePlant");
        }
    }
}
