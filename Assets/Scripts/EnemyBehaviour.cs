using System;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int enemySpeed;
    void Start()
    {

    }
    void Update()
    {
        EnemyMovement();

    }
    private void EnemyMovement()
    {
        transform.Translate(Vector3.left.normalized * enemySpeed * Time.deltaTime);
        Destroy(gameObject, 5f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Console.WriteLine("Choco enemigo");
    }

}
