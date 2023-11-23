using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private int bulletSpeed = 80;
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
        Destroy(gameObject, 0.4f);
    }
}
