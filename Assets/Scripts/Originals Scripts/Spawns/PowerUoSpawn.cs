using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUoSpawn : MonoBehaviour
{
    public GameObject speedPoweUP, extraLifePowerUp;
    private float randomX, randomY, timer = 30f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnLife();
        SpawnSpeed();
    }

    private void SpawnSpeed()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            randomX = Random.Range(0,10); 
            randomY = Random.Range(3,-5);
            Vector3 position = new Vector3(randomX, randomY, 0);
            Instantiate(speedPoweUP, position, transform.rotation);
            timer = 25f;
        }
    }

    private void SpawnLife()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            randomX = Random.Range(0, 10);
            randomY = Random.Range(3, -3);
            Vector3 position = new Vector3(randomX, randomY, 0);
            Instantiate(extraLifePowerUp, position, transform.rotation);
            timer = 35f;
        }
    }
}
