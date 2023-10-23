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
    }

    private void BulletMovement()
    {
        transform.Translate(Vector3.right.normalized * bulletSpeed * Time.deltaTime);

    }

}
