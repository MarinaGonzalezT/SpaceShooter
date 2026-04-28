using TMPro;
using UnityEngine;

public class SpaceShipScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreCount;

    int score = 0;

    void Start()
    {
        UpdateScore();
    }

    public void AddScore(int pointsEnemy)
    {
        score += pointsEnemy;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreCount.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}
