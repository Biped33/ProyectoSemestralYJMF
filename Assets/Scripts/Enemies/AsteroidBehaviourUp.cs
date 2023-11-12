using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class AsteroidBehaviourUp : MonoBehaviour
{
    private ScoreBehaviour enemyscore;
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private int enemySpeed = 10;
    private Vector3 enemyPatroll = new Vector3(0, 0, 0);

    void Start()
    {
        enemyPatroll = new Vector3(-1, Mathf.Sin(30f), 0);
        lifesUI = FindObjectOfType<LifesUIBehaviour>();
        enemyscore = FindObjectOfType<ScoreBehaviour>();
        playersLife = FindObjectOfType<PlayerBehaviour>();
    }
    void Update()
    {
        EnemyMovement();
    }
    private void EnemyMovement()
    {
        transform.Translate(enemyPatroll.normalized * enemySpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            enemyscore.AddPoints(100);
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playersLife.TakeDamage(100);
            enemyscore.SubtractPoints(100);
            lifesUI.SubstractLifes(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("WallDown"))
        {
            enemyPatroll = new Vector3(-1, Mathf.Sin(30) * -1, 0);
            transform.Translate(enemyPatroll.normalized * enemySpeed * Time.deltaTime);
        }
        if (collision.gameObject.CompareTag("WallUp"))
        {
            enemyPatroll = new Vector3(-1, Mathf.Sin(30), 0);
            transform.Translate(enemyPatroll.normalized * enemySpeed * Time.deltaTime);
        }
    }
}
