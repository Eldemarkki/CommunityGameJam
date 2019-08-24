using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private GroundCheck groundCheck;

    private Vector2 movement;
    private bool jumping;
    private bool canJump = true;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        groundCheck.groundHitEvent.AddListener(HitGround);
    }

    private void OnDisable()
    {
        groundCheck.groundHitEvent.RemoveListener(HitGround);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (canJump)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                jumping = true;
                canJump = false;
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        if (jumping)
        {
            rb.AddForce(Vector3.up * jumpForce);
            jumping = false;
        }
    }

    void HitGround(Collider2D collision)
    {
        canJump = true;
    }
}
