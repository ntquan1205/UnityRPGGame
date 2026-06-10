using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer; 
    private Vector2 lastMoveDicrection = Vector2.down;


    void FixedUpdate() 
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
  

        if (lastMoveDicrection.x < 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

        if (movement != Vector2.zero)
        {
            lastMoveDicrection = movement;
        }

        animator.SetFloat("XInput", lastMoveDicrection.x);
        animator.SetFloat("YInput", lastMoveDicrection.y);
        animator.SetFloat("Speed", movement.magnitude);

        rb.linearVelocity = new Vector2(movement.x, movement.y) * speed;
    }
}
