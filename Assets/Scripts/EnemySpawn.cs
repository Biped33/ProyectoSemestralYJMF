using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    float time = 1f;
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
            randomdX = Random.Range(1,3.5f);
            randomdY = Random.Range(-3.5f,3.5f);
            transform.position = new Vector3(randomdX, randomdY, 0);
            Instantiate(enemy, transform.position, enemy.transform.rotation);
            time = 3f;
        }
    }
}
