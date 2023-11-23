using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpaen : MonoBehaviour
{
    public GameObject bullet;
    private AudioSource audioComponent;
    private float shootDelay = 1f;
    void Start()
    {
        audioComponent = GetComponent<AudioSource>();
    }
    void Update()
    {
        ShootDelay();
    }
    private void ShootDelay()
    {
        shootDelay -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && shootDelay <= 0)
        {
            //audioComponent.Play();
            Instantiate(bullet, transform.position, Quaternion.identity);
            shootDelay = 3f;
        }
    }
}
