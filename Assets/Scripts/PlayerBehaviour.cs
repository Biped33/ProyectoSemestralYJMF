using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private int playerSpeed = 5;
    Vector2 playerPosition;
    void Start()
    {

    }
    void Update()
    {
        PlayerMovement(transform, playerSpeed, playerPosition);
    }


    void PlayerMovement(Transform transform, int playerSpeed, Vector3 playerPosition)
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerPosition = new Vector2(0, 1);
            transform.Translate(playerPosition.normalized * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerPosition = new Vector2(0, -1);
            transform.Translate(playerPosition.normalized * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerPosition = new Vector2(1, 0);
            transform.Translate(playerPosition.normalized * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerPosition = new Vector2(-1, 0);
            transform.Translate(playerPosition.normalized * playerSpeed * Time.deltaTime);
        }
    }
}
