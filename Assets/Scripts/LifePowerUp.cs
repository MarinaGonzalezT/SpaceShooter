using UnityEngine;

public class LifePowerUp : MonoBehaviour
{
    [SerializeField] int healAmount = 2;
    [SerializeField] float speed = 1f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SpaceShipLife playerLife = collision.collider.GetComponent<SpaceShipLife>();

            if (playerLife != null)
                { playerLife.Heal(healAmount); }

            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }
}
