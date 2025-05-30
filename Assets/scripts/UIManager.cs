using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Image currentHPBar;
    private float HPFillAmount = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getScore(int newScore)
    {
        scoreText.text = "Score " + newScore;
    }

    public void UpdateHP(float perc)
    {
        currentHPBar.fillAmount = perc;
        if (perc <= 0.2f)
        {
            currentHPBar.color = Color.red;
        }
        else if (perc <= 0.5f)
        {
            currentHPBar.color = Color.yellow;
        }
        else
        {
            currentHPBar.color = Color.green;
        }
    }
}
