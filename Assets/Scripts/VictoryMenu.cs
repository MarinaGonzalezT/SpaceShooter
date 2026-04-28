using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject recordYes;
    [SerializeField] GameObject recordNo;

    [SerializeField] TextMeshProUGUI scoreRecordYesText;
    [SerializeField] TextMeshProUGUI scoreRecordNoText;
    [SerializeField] TextMeshProUGUI recordText;

    SpaceShipScore score;

    void Awake()
    {
        score = FindFirstObjectByType<SpaceShipScore>();
    }

    void Start()
    {
        panel.SetActive(false);
    }

    public void ShowVictory()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);

        int currentScore = score.GetScore();
        int record = PlayerPrefs.GetInt("RecordScore", 0);

        if (currentScore > record)
        {
            PlayerPrefs.SetInt("RecordScore", currentScore);
            PlayerPrefs.Save();

            recordYes.SetActive(true);
            recordNo.SetActive(false);

            scoreRecordYesText.text = currentScore.ToString();
        }
        else
        {
            recordYes.SetActive(false);
            recordNo.SetActive(true);

            scoreRecordNoText.text = currentScore.ToString();
            recordText.text = record.ToString();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
