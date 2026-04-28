using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] int damage = 1;
    Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb2D.linearVelocity = Vector2.left * speed;
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SpaceShipLife playerLife = collision.collider.GetComponent<SpaceShipLife>();

            if (playerLife != null)
            { playerLife.TakeDamage(damage); }

            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Limit") 
            || collision.collider.CompareTag("PlayerShot")
            || collision.collider.CompareTag("Enemy")
            || collision.collider.CompareTag("Life"))
        {
            Destroy(gameObject);
        }
    }
}
