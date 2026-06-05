using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    public Animator animator;

    void FixedUpdate() 
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        animator.SetFloat("XInput", horizontal);
        animator.SetFloat("YInput", vertical);

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
    }
}
