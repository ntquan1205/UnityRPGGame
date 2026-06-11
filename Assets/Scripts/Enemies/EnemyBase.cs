using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float moveSpeed = 2f;
    protected Transform player;
    SpriteRenderer spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (player != null)
        {
            Vector2 dir =(player.position - transform.position).normalized;
            transform.Translate(dir * moveSpeed * Time.deltaTime);
        }

        if (player.position.x > transform.position.x)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            Debug.Log("EEnenmy hit player");
        }
    }
}
