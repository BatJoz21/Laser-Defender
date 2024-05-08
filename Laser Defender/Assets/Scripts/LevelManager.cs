using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float sceneLoadDelay = 1.0f;
    [SerializeField] private GameObject creditsPanel;

    private ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        scoreKeeper.ResetScore();
    }

    public void LoadCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void ExitCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitOnLoad("Game Over", sceneLoadDelay));
    }

    IEnumerator WaitOnLoad(string sceneName, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
