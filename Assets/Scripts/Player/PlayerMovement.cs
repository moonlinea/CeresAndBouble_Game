using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    float direction = 0;

    [SerializeField] private float speed = 400;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
    }

    void FixedUpdate()
    {
        MovePlayer();
        UpdateAnimator();
        FlipIfNeeded();
    }

    void MovePlayer()
    {
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
    }

    void UpdateAnimator()
    {
        animator.SetFloat("speed", Mathf.Abs(direction));
    }

    void FlipIfNeeded()
    {
        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
