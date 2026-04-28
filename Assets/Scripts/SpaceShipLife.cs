using UnityEngine;

public class SpaceShipLife : MonoBehaviour
{
    [SerializeField] int maxLife = 6;
    [SerializeField] GameObject[] lifePartsFront;
    [SerializeField] GameObject[] lifePartsBackground;

    int currentLife;

    void Start()
    {
        currentLife = maxLife;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        currentLife -= damage;
        currentLife = Mathf.Clamp(currentLife, 0, maxLife);

        UpdateHearts();

        if (currentLife <= 0)
        {
            FindFirstObjectByType<GameOverMenu>().ShowGameOver();
            Destroy(gameObject);
        }
    }

    public void Heal(int amount)
    {
        currentLife += amount;
        currentLife = Mathf.Clamp(currentLife, 0, maxLife);

        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < lifePartsFront.Length; i++)
        {
            if (i < currentLife)
            {
                lifePartsFront[i].SetActive(true);
                lifePartsBackground[i].SetActive(false);
            }
            else
            {
                lifePartsFront[i].SetActive(false);
                lifePartsBackground[i].SetActive(true);
            }
        }
    }
}
