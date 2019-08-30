using UnityEngine;

public class Footsteps : MonoBehaviour
{
    float timeSincePlayed = 0;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        timeSincePlayed += Time.deltaTime;

        if(timeSincePlayed >= 0.3f && rb.velocity.magnitude > 0.5f){
            SoundManager.instance.Play("Footstep", 0.8f, 1.5f);
            timeSincePlayed = 0;
        }
    }
}
