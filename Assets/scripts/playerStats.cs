using UnityEngine;

public class playerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            var manager = FindFirstObjectByType<GameManager>();
            manager.StartGameOver();
        }
    }

    public void takeDamage(float damange)
    { 
        currentHealth -= damange;
        GameManager manager = FindFirstObjectByType<GameManager>();
        manager.getHPerc(maxHealth, currentHealth);
        Debug.Log("Current HP: " + currentHealth);
    }
}
