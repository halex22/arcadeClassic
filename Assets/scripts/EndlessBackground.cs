using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    private MeshRenderer mr;
    private Material material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        material = mr.material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new (transform.position.x / transform.localScale.x, transform.position.y / transform.localScale.z);
        material.mainTextureOffset = offset;
    }
}
