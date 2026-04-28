using System.Collections;
using UnityEngine;

public class EnemySpaceShipRed : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float leftLimitCoordinate = -4f;
    [SerializeField] int damage = 2;
    [SerializeField] int points = 250;

    [SerializeField] GameObject prefabShot;
    [SerializeField] Transform shootingPoint;
    [SerializeField] float timeBetweenShots = 0.5f;

    SpaceShipScore score;
    LifeDropGenerator lifeDropGenerator;

    void Awake()
    {
        score = FindFirstObjectByType<SpaceShipScore>();
        lifeDropGenerator = FindFirstObjectByType<LifeDropGenerator>();
    }

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < leftLimitCoordinate)
            { Destroy(gameObject); }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShots);

            Instantiate(prefabShot, shootingPoint.position, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerShot"))
        {
            score.AddScore(points);

            if (lifeDropGenerator != null)
            { lifeDropGenerator.EnemyKilled(transform.position); }

            Destroy(gameObject);
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
