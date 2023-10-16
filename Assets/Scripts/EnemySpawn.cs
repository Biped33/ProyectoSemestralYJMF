using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {

    }


    void Update()
    {
        int screenRange = Random.Range(0, 5);
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
