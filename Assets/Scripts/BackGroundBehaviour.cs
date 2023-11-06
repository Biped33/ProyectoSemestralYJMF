using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundBehaviour : MonoBehaviour
{
    [SerializeField] private Vector2 movementVelocityBG;
    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        offset = movementVelocityBG * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
