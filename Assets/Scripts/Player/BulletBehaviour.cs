using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public int bulletSpeed = 10;
    void Start()
    {
    }
    void Update()
    {
        BulletMovement();
        AutoDestroy();
    }

    private void BulletMovement()
    {
        transform.Translate(Vector3.right.normalized * bulletSpeed * Time.deltaTime);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject, 1.61f);
    }
}
