using UnityEngine;

public class AsteroidBehaviourDown : MonoBehaviour
{
    private ScoreBehaviourLevel1 enemyscore;
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private SpriteRenderer hide;
    private SphereCollider sCollider;
    //public Animator deadAnimation;
    private int enemySpeed = 10;
    private Vector3 enemyPatroll = new Vector3(0, 0, 0);

    void Start()
    {
        enemyPatroll = new Vector3(-1, Mathf.Cos(180f), 0);
        hide = GetComponent<SpriteRenderer>();
        sCollider = GetComponent<SphereCollider>();
        lifesUI = FindObjectOfType<LifesUIBehaviour>();
        enemyscore = FindObjectOfType<ScoreBehaviourLevel1>();
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
            //deadAnimation.SetTrigger("dead");
            hide.enabled = false;
            sCollider.enabled = false;
            Invoke("AutoDestroy", 1f);

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
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
