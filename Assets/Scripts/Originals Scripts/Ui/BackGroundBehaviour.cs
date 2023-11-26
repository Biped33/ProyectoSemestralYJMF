using UnityEngine;

public class BackGroundBehaviour : MonoBehaviour
{
    [SerializeField] private Vector2 movementVelocityBG;
    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        FindObjects();
    }

    void Update()
    {
        offset = movementVelocityBG * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

    private void FindObjects()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
}
