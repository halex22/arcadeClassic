using UnityEngine;

public class Asteroid : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {
        base.Start();
        float RandomScale = Random.Range(0.5f, 2f);
        transform.localScale = new Vector3 (RandomScale, RandomScale, 1f);
        Vector2 randomDireciton = Random.insideUnitCircle.normalized;
        rb.AddForce(randomDireciton * Random.Range(0.5f, speed), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    new void Update()
    {
        if (hitpoints <= 0) onDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.getDamage(999);
            getDamage(1);
        }
    }
}
