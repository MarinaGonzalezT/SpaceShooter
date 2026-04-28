using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] prefabsEnemies;
    [SerializeField] float[] timesBetweenShips;
    [SerializeField] Transform top;
    [SerializeField] Transform bottom;

    [SerializeField] int maxEnemiesInScene = 3;
    [SerializeField] int maxEnemiesLimit = 10;
    [SerializeField] float timeBetweenDifficultyIncrease = 15f;

    [SerializeField] GameObject prefabBoss;
    [SerializeField] Transform bossSpawnPoint;

    bool bossHasAppeared = false;
    bool canGenerateEnemies = true;

    void Start()
    {
        for (int i = 0; i < prefabsEnemies.Length; i++)
        {
            StartCoroutine(Generate(i));
        }

        StartCoroutine(IncreaseDifficulty());
    }

    IEnumerator Generate(int index)
    {
        while (canGenerateEnemies)
        {
            yield return new WaitForSeconds(timesBetweenShips[index]);

            if (CountEnemiesInScene() < maxEnemiesInScene)
            {
                Vector3 position = Vector3.Lerp(top.position, bottom.position, Random.Range(0f, 1f));

                Instantiate(prefabsEnemies[index], position, Quaternion.identity);
            }
        }
    }

    IEnumerator IncreaseDifficulty()
    {
        while (maxEnemiesInScene < maxEnemiesLimit)
        {
            yield return new WaitForSeconds(timeBetweenDifficultyIncrease);

            maxEnemiesInScene++;
        }

        yield return new WaitForSeconds(timeBetweenDifficultyIncrease);

        SpawnBoss();
    }

    int CountEnemiesInScene()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void SpawnBoss()
    {
        if (bossHasAppeared) return;

        bossHasAppeared = true;
        canGenerateEnemies = false;

        Instantiate(prefabBoss, bossSpawnPoint.position, Quaternion.identity);
    }
}
