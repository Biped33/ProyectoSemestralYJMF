using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private int playerSpeed = 5;
    private int life = 3;
    private EnemyBehaviour enemyDamage;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyDamage.EnemyDamage(1);
            if (life == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
