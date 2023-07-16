using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private TMP_Text levelText;

    private int levelIndex;
    private void Start()
    {
        levelIndex = PlayerPrefs.GetInt("LevelIndex");
        levelText.text = "Level: " + levelIndex.ToString();
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
        gamePanel.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void PlayerWin()
    {
        winPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        gamePanel.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("LevelIndex", levelIndex+1);
        PlayerPrefs.Save();

        SceneManager.LoadScene(1);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
