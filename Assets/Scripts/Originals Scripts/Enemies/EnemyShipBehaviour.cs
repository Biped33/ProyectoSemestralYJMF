using UnityEngine;

public class EnemyShipBehaviour : MonoBehaviour
{
    //public Animator deadAnimation;
    private ScoreBehaviourLevel2 enemyscore;
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private SpriteRenderer hide;
    private SphereCollider sCollider;
    private int lifeEnemyShip = 200;
    private int enemySpeed = 13;
    //private AudioSource audioComponent;
    void Start()
    {
        FindObjects();
        //audioComponent = GetComponent<AudioSource>();
    }
    void Update()
    {
        EnemyMovement();
    }

    private void FindObjects()
    {
        hide = GetComponent<SpriteRenderer>();
        sCollider = GetComponent<SphereCollider>();
        lifesUI = FindObjectOfType<LifesUIBehaviour>();
        enemyscore = FindObjectOfType<ScoreBehaviourLevel2>();
        playersLife = FindObjectOfType<PlayerBehaviour>();
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
                //audioComponent.Play();
                //deadAnimation.SetTrigger("dead");
                hide.enabled = false;
                sCollider.enabled = false;
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