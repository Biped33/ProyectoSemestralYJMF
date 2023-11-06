using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipBehaviour : MonoBehaviour
{
    private ScoreBehaviour enemyscore;
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private int enemySpeed = 10;
    public Animator deadAnimation;
    private SpriteRenderer hide;
    private SphereCollider sCollider;
    void Start()
    {
        hide = GetComponent<SpriteRenderer>();
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
        transform.Translate(Vector3.left.normalized * enemySpeed * Time.deltaTime);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            enemyscore.AddPoints(100);
            Destroy(collision.gameObject);
            deadAnimation.SetTrigger("dead");
            hide.enabled = false;
            sCollider.enabled = false;
            Invoke("AutoDestroy", 1);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playersLife.TakeDamage(100);
            enemyscore.SubtractPoints(200);
            lifesUI.SubstractLifes(1);
            Destroy(gameObject);
        }
    }
}
