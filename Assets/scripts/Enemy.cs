using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;
    public float hitpoints = 1f;

    public SpriteRenderer spriteRenderer;

    private GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.down * speed * Time.deltaTime);

        Vector2 moveDirection = Vector2.MoveTowards(transform.position, manager.player.transform.position, speed * Time.deltaTime);
        Vector2 distance = manager.player.transform.position - transform.position;
        float angle = Mathf.Atan2(distance.x, distance.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, -angle);
        transform.position = moveDirection;
        if (hitpoints <= 0) onDeath();
    }

    public void getDamage(float damage)
    {
        hitpoints -= damage;
    }

    void onDeath()
    {
        manager.addScore(100);
        Destroy(gameObject);
    }
}
