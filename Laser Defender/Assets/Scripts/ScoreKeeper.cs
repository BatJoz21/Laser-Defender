using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int currentScore = 0;

    private static ScoreKeeper instance;

    void Awake()
    {
        ManageScoreKeeper();
    }

    public int CurrentScore { get => currentScore; }

    public void ModifyScore(int score) 
    {
        currentScore += score;
    }

    public void ResetScore() { currentScore = 0; }

    private void ManageScoreKeeper()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
