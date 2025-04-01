using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public GameObject creditPanel;

    void Start()
    {
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
        creditPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowVictory()
    {
        victoryPanel.SetActive(true);
    }

    public void ShowCredits()
    {
        creditPanel.SetActive(true);
    }

    public void HideCredits()
    {
        creditPanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
