using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMovement : MonoBehaviour
{
    private int bulletSpeed = 10;
    private Vector3 bulletPosition;
    void Start()
    {

    }

    void Update()
    {
        bulletPosition = new Vector3(1, 0, 0);
        transform.Translate(bulletPosition * bulletSpeed * Time.deltaTime);
    }


}
