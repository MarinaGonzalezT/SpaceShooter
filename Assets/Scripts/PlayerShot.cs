using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private float speed = 3f;
    Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb2D.linearVelocity = Vector2.right * speed;
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") 
            || collision.collider.CompareTag("Limit")
            || collision.collider.CompareTag("EnemyShot")
            || collision.collider.CompareTag("Life"))
        {
            Destroy(gameObject);
        }
    }
}
