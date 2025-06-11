using UnityEngine;

public class BossTurrent : MonoBehaviour
{
    public GameObject gun;
    public TurrentArmor ammo;

    public float HP = 1f; // Health points for the turret
    public bool isActive = true; // Indicates if the turret is active

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(Vector2 direction)
    {
        // Implement firing logic here
        TurrentArmor newAmmo = Instantiate(ammo, gun.transform.position, Quaternion.identity);
        newAmmo.PushToPlayer(direction);
    }
    public void Damage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.color = Color.gray;
            isActive = false; // Deactivate the turret
        }
    }

}
