using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    float time = 5f;
    public float randomdX;
    public float randomdY;
    void Start()
    {


    }


    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            randomdX = Random.Range(1,4.5f);
            randomdY = Random.Range(-4.5f,4.5f);
            transform.position = new Vector3(randomdX, randomdY, 0);
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }
    }
}
