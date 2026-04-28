using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] float entrySpeed = 1f;
    [SerializeField] float verticalSpeed = 2f;
    [SerializeField] float leftLimitCoordinate = 3f;
    [SerializeField] float topLimitCoordinate = 3f;
    [SerializeField] float bottomLimitCoordinate = -3f;

    [SerializeField] int maxHits = 15;
    [SerializeField] int points = 5000;

    [SerializeField] GameObject prefabShot;
    [SerializeField] Transform shootingPointTop;
    [SerializeField] Transform shootingPointBottom;
    [SerializeField] float timeBetweenShots = 0.7f;

    SpaceShipScore score;

    int contHits = 0;
    bool hasEntered = false;
    bool isGoingUp = true;
    bool shootFromTop = true;

    void Awake()
    {
        score = FindFirstObjectByType<SpaceShipScore>();
    }

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        if (!hasEntered)
        {
            transform.Translate(Vector2.left * entrySpeed * Time.deltaTime);

            if (transform.position.x <= leftLimitCoordinate)
            {
                hasEntered = true;
            }

            return;
        }

        MoveVertical();
    }

    void MoveVertical()
    {
        Vector2 direction = isGoingUp ? Vector2.up : Vector2.down;
        transform.Translate(direction * verticalSpeed * Time.deltaTime);

        if (isGoingUp && transform.position.y >= topLimitCoordinate)
            { isGoingUp = false; }

        if (!isGoingUp && transform.position.y <= bottomLimitCoordinate)
            { isGoingUp = true; }
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeBetweenShots);

            if (hasEntered)
            {
                if (shootFromTop)
                    { Instantiate(prefabShot, shootingPointTop.position, Quaternion.identity); }
                else
                    { Instantiate(prefabShot, shootingPointBottom.position, Quaternion.identity); }

                shootFromTop = !shootFromTop;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerShot"))
        {
            contHits++;

            if (contHits >= maxHits)
            {
                score.AddScore(points);

                Destroy(gameObject);

                FindFirstObjectByType<VictoryMenu>().ShowVictory();
            }
        }
    }
    }
