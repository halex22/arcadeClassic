using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;
    public float hitpoints = 1f;

    public SpriteRenderer spriteRenderer;

    private GameManager manager;

    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected void Update()
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
        Debug.Log("Getting hit");
        hitpoints -= damage;
    }

    public void onDeath()
    {
        manager.addScore(100);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerStats ps = collision.gameObject.GetComponent<playerStats>();
            ps.takeDamage(5f);

        }
    }
}
