using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject bullet;
    private AudioSource audioComponent;
    void Start()
    {
        audioComponent = GetComponent<AudioSource>();
    }
    void Update()
    {
        SpawnBullet();
    }
    private void SpawnBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            
        {
            audioComponent.Play();
            Instantiate(bullet, transform.position, Quaternion.identity);
        }

    }
}
