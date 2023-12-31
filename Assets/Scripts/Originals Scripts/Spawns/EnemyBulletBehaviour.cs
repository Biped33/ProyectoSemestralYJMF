using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private ScoreBehaviourLevel2 enemyscore;
    public GameObject deadAnimation;
    private int bulletSpeed = 15;

    void Start()
    {
        FindObjects();
    }

    void Update()
    {
        BulletMovement();
    }

    private void FindObjects()
    {
        lifesUI = FindObjectOfType<LifesUIBehaviour>();
        playersLife = FindObjectOfType<PlayerBehaviour>();
        enemyscore = FindObjectOfType<ScoreBehaviourLevel2>();
    }

    private void BulletMovement()
    {
        transform.Translate(Vector3.right.normalized * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playersLife.TakeDamage(100);
            enemyscore.SubtractPoints(150);
            lifesUI.SubstractLifes(1);
            Instantiate(deadAnimation, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
