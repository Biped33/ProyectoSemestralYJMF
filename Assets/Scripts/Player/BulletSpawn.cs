using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject bullet;
    private AudioSource audioComponent;
    private float shootRecharge = 1f;
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
        shootRecharge-= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && shootRecharge <= 0) 
        {
            audioComponent.Play();
            Instantiate(bullet, transform.position, Quaternion.identity);
            shootRecharge = 0.3f;
        }

    }
}
