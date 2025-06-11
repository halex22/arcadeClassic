using UnityEngine;

public class BossTurrent : MonoBehaviour
{
    public GameObject gun;
    public TurrentArmor ammo;
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
}
