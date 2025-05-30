using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        scoreText.text = scoreManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
