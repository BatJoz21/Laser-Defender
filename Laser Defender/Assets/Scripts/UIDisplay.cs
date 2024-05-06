using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private Health healthScript;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = healthScript.GetHealth;
    }

    void Update()
    {
        ShowUIHealth();
        ShowUIScore();
    }

    private void ShowUIHealth()
    {
        healthSlider.value = healthScript.GetHealth;
    }

    private void ShowUIScore()
    {
        scoreText.text = scoreKeeper.CurrentScore.ToString("00000");
    }
}
