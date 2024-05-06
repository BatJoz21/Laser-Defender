using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int currentScore = 0;

    public int CurrentScore { get => currentScore; }

    public void ModifyScore(int score) 
    {
        currentScore += score;
        Debug.Log(currentScore);
    }

    public void ResetScore() { currentScore = 0; }
}
