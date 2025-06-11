using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed = 10f;
    public float lifespan = 0.5f;
    public float damage = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "hazard")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.getDamage(damage);
            lifespan = 0;
        }
        Debug.Log("collision");
    }
}