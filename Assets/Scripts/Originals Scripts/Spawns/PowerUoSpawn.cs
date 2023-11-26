using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUoSpawn : MonoBehaviour
{
    public GameObject speedPoweUP, extraLifePowerUp;
    private float randomX, randomY, timer1 = 5f, timer2 = 15f;
    void Start()
    {

    }
    void Update()
    {
        SpawnLife();
        SpawnSpeed();
    }

    private void SpawnSpeed()
    {
        timer1 -= Time.deltaTime;
        if (timer1 <= 0)
        {
            randomX = Random.Range(16, 18);
            randomY = Random.Range(8, -8);
            Vector3 position = new Vector3(randomX, randomY, 0);
            Instantiate(speedPoweUP, position, Quaternion.Euler(0,0,-180));
            timer1 = 15f;
        }
    }

    private void SpawnLife()
    {
        timer2 -= Time.deltaTime;
        if (timer2 <= 0)
        {
            randomX = Random.Range(16, 18);
            randomY = Random.Range(8, -8);
            Vector3 position = new Vector3(randomX, randomY, 0);
            Instantiate(extraLifePowerUp, position, transform.rotation);
            timer2 = 30f;
        }
    }
}
