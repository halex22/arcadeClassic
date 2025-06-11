using UnityEngine;

public class SpaceStationBoss : MonoBehaviour
{
    public BossTurrent[] turrents;
    public float fireCD = 1f;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerControler>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
