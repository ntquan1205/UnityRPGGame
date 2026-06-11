using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    private int facingDirection = -1;
    private EnemyState enemyState;
    public float attackRange = 2;
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }

    // Update is called once per frame jj
    void Update()
    {
        if (enemyState == EnemyState.Chasing)
        {
            Chase();
        }
        else if (enemyState == EnemyState.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void Chase()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= attackRange)
        {
            ChangeState(EnemyState.Attacking);
        }
        else if (player.position.x > transform.position.x && facingDirection == -1 || player.position.x < transform.position.x && facingDirection == 1) 
        {
            Flip();
        }
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;  
        
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y, transform.localScale.z);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }
            ChangeState(EnemyState.Chasing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.Idle) 
            anim.SetBool("IsIdle", false);
        else if (enemyState == EnemyState.Chasing) 
            anim.SetBool("IsChasing", false);
        else if (enemyState == EnemyState.Attacking) 
            anim.SetBool("IsAttacking", false);

        enemyState = newState;

        if (enemyState == EnemyState.Idle) 
            anim.SetBool("IsIdle", true);
        else if (enemyState == EnemyState.Chasing) 
            anim.SetBool("IsChasing", true);
        else if (enemyState == EnemyState.Attacking) 
            anim.SetBool("IsAttacking", true);
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking
}
