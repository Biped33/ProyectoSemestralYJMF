using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class EnemyShipShootingBehaviour : MonoBehaviour
{
    //public Animator deadAnimation;
    private ScoreBehaviourLevel2 enemyscore;
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private SpriteRenderer hide;
    private BoxCollider bCollider;
    private int lifeEnemyShip = 200;
    private int enemySpeed = 13;
    private float shootDelay = 3;
    public GameObject bullet;
    private AudioSource audioComponent;
    void Start()
    {
        FindObjects();
    }
    void Update()
    {
        EnemyMovement();
        Shoot();
    }

    private void FindObjects()
    {
        hide = GetComponent<SpriteRenderer>();
        bCollider = GetComponent<BoxCollider>();
        lifesUI = FindObjectOfType<LifesUIBehaviour>();
        enemyscore = FindObjectOfType<ScoreBehaviourLevel2>();
        playersLife = FindObjectOfType<PlayerBehaviour>();
        audioComponent = GetComponent<AudioSource>();
    }
    private void EnemyMovement()
    {
        transform.Translate(Vector3.left.normalized * enemySpeed * Time.deltaTime);
    }
    private void TakeDamage(int damage)
    {
        lifeEnemyShip -= damage;
    }
    private void AutoDestroy()
    {
        Destroy(gameObject);
    }
    private void Shoot()
    {
        if (shootDelay <= 0 && lifeEnemyShip >= 200)
        {
            audioComponent.Play();
            Instantiate(bullet, transform.position, Quaternion.identity);
            shootDelay = 3;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            TakeDamage(100);
            Destroy(collision.gameObject);
            if (lifeEnemyShip <= 0)
            {
                enemyscore.AddPoints(150);
                Destroy(collision.gameObject);
                //deadAnimation.SetTrigger("dead");
                hide.enabled = false;
                bCollider.enabled = false;
                Invoke("AutoDestroy", 1);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playersLife.TakeDamage(200);
            enemyscore.SubtractPoints(350);
            lifesUI.SubstractLifes(2);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
