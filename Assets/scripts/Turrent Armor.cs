using UnityEngine;

public class TurrentArmor : Ammo
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {

    }

    // Update is called once per frame
    new void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void PushToPlayer(Vector2 dir)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(dir * speed, ForceMode2D.Impulse);

    }
}
