using UnityEngine;

public class SpaceStationBoss : MonoBehaviour
{
    public BossTurrent[] turrents;
    public float fireCD = 1f;
    public GameObject player;
    public GameObject nucleo;
    public float openingCD = 3f; 
    public float openingTime = 0f;
    public bool isOpen = false;
    public bool isOpening = true;
    public float hp = 1f;
    public GameObject BossBody; // Reference to the boss body GameObject


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerControler>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        fireCD -= Time.deltaTime;
        if (fireCD <= 0)
        {
            ClosestTurrent();
            fireCD = 1f; 
        }

        openingCD -= Time.deltaTime;
        if (openingCD == 0)
        { 
            isOpen = true;
            nucleo.SetActive(true);
            NucleoOpening();
        }
    }

    void ClosestTurrent()
    {
        BossTurrent clasest = turrents[0];
        float closestDistance = Vector2.Distance(player.transform.position, clasest.transform.position);
        foreach (BossTurrent turrent in turrents)
        {
            if (!turrent.isActive) continue; // Skip inactive turrents
            float distance = Vector2.Distance(player.transform.position, turrent.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                clasest = turrent;
            }
        }
        clasest.Fire(player.transform.position - clasest.transform.position);
    }

    void NucleoOpening() 
    {
        isOpening = openingTime <= 0 ? true : openingTime >= 3f ? false : isOpening;
        if (isOpening)
        {
            openingTime += Time.deltaTime;
        }
        else 
        {
            openingTime -= Time.deltaTime;
            if (openingTime <= 0f)
            {
                isOpen = false;
                nucleo.SetActive(false);
                openingCD = 3f; // Reset the opening cooldown
            }
        }

        SpriteRenderer sr = nucleo.GetComponent<SpriteRenderer>();

        if (openingTime <= 1f)
        {
            sr.color = Color.green;
        }
        if (openingTime > 1f && openingTime <= 2f)
        {
            sr.color = Color.yellow;
        }
        if (openingTime > 2f && openingTime <= 3f)
        {
            sr.color = Color.red;
        }
    }

    public void Damage(float damage)
    {
        if (!isOpen) return;
        hp -= damage;
        if (hp <= 0)
        { 
            Destroy(BossBody)
        }
    }

}
