using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private UIManager UImanager;
    private int playerScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerControler>().gameObject;
        UImanager = FindAnyObjectByType<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int scoreToAdd)
    { 
        playerScore += scoreToAdd;
        UImanager.getScore(playerScore);
    }
}
