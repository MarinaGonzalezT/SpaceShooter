using UnityEngine;

public class LifeDropGenerator : MonoBehaviour
{
    [SerializeField] GameObject prefabLife;

    int enemiesNeededForLife = 10;
    int enemiesKilled = 0;

    public void EnemyKilled(Vector3 position)
    {
        enemiesKilled++;

        if (enemiesKilled >= enemiesNeededForLife)
        {
            Instantiate(prefabLife, position, Quaternion.identity);
            enemiesKilled = 0;
            enemiesNeededForLife += 5;
        }
    }
}
