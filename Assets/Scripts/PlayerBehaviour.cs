using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private int playerSpeed = 5;
    void Start()
    {

    }
    void Update()
    {
        PlayerMovement(transform, playerSpeed);
    }


    void PlayerMovement(Transform transform, int playerSpeed)
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up.normalized * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down.normalized * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right.normalized * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left.normalized * playerSpeed * Time.deltaTime);
        }
    }
}
