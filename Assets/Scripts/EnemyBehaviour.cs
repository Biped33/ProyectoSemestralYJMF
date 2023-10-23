using System;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private ScoreBehaviour enemyscore;
    public int enemySpeed;
    private int damage = 0;
    void Start()
    {
        enemyscore = FindObjectOfType<ScoreBehaviour>();
    }
    void Update()
    {
        EnemyMovement();

    }
    private void EnemyMovement()
    {
        transform.Translate(Vector3.left.normalized * enemySpeed * Time.deltaTime);
        Destroy(gameObject, 5f);

    }

    public void EnemyDamage(int damageToPlayer)
    {
        damage = damage - damageToPlayer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullets")
        {
            enemyscore.AddPoints(100);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }


}
