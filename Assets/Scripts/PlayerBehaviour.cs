using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private int playerSpeed = 5;
    private int life = 300;
    private void Start()
    {
    }
    private void Update()
    {
        PlayerMovement(transform, playerSpeed);
    }
    private void PlayerMovement(Transform transform, int playerSpeed)
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up.normalized * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down.normalized * playerSpeed * Time.deltaTime);
        }
    }
    public void TakeDamage(int enemyDamage)
    {
        life -= enemyDamage;
        if (life <= 0)
        {
            WinLoseConditions.instance.LoseCondition();
        }
    }

   
}
