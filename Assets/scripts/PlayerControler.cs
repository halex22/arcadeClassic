using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;

public class PlayerControler : MonoBehaviour
{
    public float speed = 8f;

    private Vector2 screenBounce;
    private SpriteRenderer spriteRenderer;

    public Transform gun;
    public Ammo ammo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounce = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalPos = Input.GetAxisRaw("Horizontal");
        float verticalPos = Input.GetAxisRaw("Vertical");
        
        Vector2 newPos = new(horizontalPos, verticalPos);
        transform.Translate(newPos * speed * Time.deltaTime , Space.World);

        //float boundX = spriteRenderer.bounds.extents.x;
        //float boundY = spriteRenderer.bounds.extents.y;

        //float clampX = Mathf.Clamp(transform.position.x, -screenBounce.x + boundX, screenBounce.x - boundX);
        //float clampY = Mathf.Clamp(transform.position.y, -screenBounce.y + boundY, screenBounce.y - boundY);
        //transform.position = new Vector2(clampX, clampY);
        //Debug.Log(horizontalPos + " - " + verticalPos);

        float angle = Mathf.Atan2(newPos.x, newPos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, -angle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Die !!!!!");
            Instantiate(ammo, gun.position, transform.rotation);
        }
    }


}
