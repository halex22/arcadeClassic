using UnityEngine;

public class Spawer : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    public Enemy enemy;
    public float spawnCoolDown = 1f;
    public float generalSpawnCD = 1f;

    Vector2 upRigth = Vector2.zero;
    Vector2 downLeft= Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        upRigth = Camera.main.ViewportToWorldPoint(new Vector3(1,1, Camera.main.nearClipPlane));
        downLeft = Camera.main.ViewportToWorldPoint(new Vector3(0,0, Camera.main.nearClipPlane));
        //float maxWidth = SpriteRenderer.bounds.extents.x;
        //float minWidth = -maxWidth;

        //float randomX = Random.Range(minWidth, maxWidth);

        spawnCoolDown -= Time.deltaTime;

        if (spawnCoolDown < 0)
        {
            int randomDirection = Random.Range(1, 5);
            Vector2 randomPos = Vector2.zero;

            SpriteRenderer enemySprite = enemy.GetComponent<SpriteRenderer>();
            float enemyMaxWidth = enemySprite.bounds.extents.x;
            float enemyMaxHeight = enemySprite.bounds.extents.y;
            float randX = Random.Range(downLeft.x - enemyMaxWidth, upRigth.x + enemyMaxWidth);
            float randY = Random.Range(downLeft.y - enemyMaxHeight, upRigth.y + enemyMaxHeight);

            if (randomDirection == 1)
            {
                float fixdY = upRigth.y + enemyMaxHeight;
                randomPos = new Vector2(randX, fixdY); 
            }
            if (randomDirection == 2)
            {
                float fixdX = upRigth.x + enemyMaxWidth;
                randomPos = new Vector2(fixdX, randY);
            }
            if (randomDirection == 3)
            {
                float fexdy = downLeft.x - enemyMaxWidth;
                randomPos = new Vector2 (fexdy, randY);
            }
            if (randomDirection == 4)
            {
                float fixdX = downLeft.x - enemyMaxWidth;
                randomPos = new Vector2 (fixdX, randY);
            }
            //Instantiate(enemy, new Vector2(randomX, transform.position.y), Quaternion.identity);
            Instantiate(enemy, randomPos, Quaternion.identity);
            spawnCoolDown = generalSpawnCD;
        }
    }
}
