using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.ChangeHealth(-damage);
            }
        }
    }
    public void Attack()
    {
        Debug.Log("Attacking player");
    }
}
