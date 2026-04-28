using UnityEngine;

public class EnemySpaceShipBlue : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float leftLimitCoordinate = -3f;
    [SerializeField] float rightLimitCoordinate = 3f;
    [SerializeField] int damage = 1;
    [SerializeField] int points = 500;

    SpaceShipScore score;
    LifeDropGenerator lifeDropGenerator;
    bool isGoingLeft = true;
    int contHits = 0;

    void Awake()
    {
        score = FindFirstObjectByType<SpaceShipScore>();
        lifeDropGenerator = FindFirstObjectByType<LifeDropGenerator>();
    }

    void Update()
    {
        Vector2 direction = isGoingLeft ? Vector2.left : Vector2.right;
        transform.Translate(direction * speed * Time.deltaTime);

        if (isGoingLeft && (transform.position.x < leftLimitCoordinate))
            { isGoingLeft = false; }

        if (!isGoingLeft && (transform.position.x > rightLimitCoordinate))
            { Destroy(gameObject); }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerShot"))
        {
            contHits++;
            if (contHits == 2)
            {
                score.AddScore(points);

                if (lifeDropGenerator != null)
                { lifeDropGenerator.EnemyKilled(transform.position); }

                Destroy(gameObject);
                contHits = 0;
            }
        }

        if (collision.collider.CompareTag("Player"))
        {
            SpaceShipLife playerLife = collision.collider.GetComponent<SpaceShipLife>();

            if (playerLife != null)
                { playerLife.TakeDamage(damage); }

            Destroy(gameObject);
        }
    }
}
