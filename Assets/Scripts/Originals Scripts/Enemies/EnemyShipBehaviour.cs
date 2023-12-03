using UnityEngine;

public class EnemyShipBehaviour : MonoBehaviour
{
    public GameObject deadAnimation;
    private ScoreBehaviourLevel2 enemyscore;
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private SpriteRenderer hide;
    private SphereCollider sCollider;
    private int lifeEnemyShip = 100;
    private int enemySpeed = 20;
    private AudioSource audioComponent;

    void Start()
    {
        FindObjects();
    }
    void Update()
    {
        EnemyMovement();
    }

    private void FindObjects()
    {
        audioComponent = GetComponent<AudioSource>();
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
                enemyscore.AddPoints(200);
                Destroy(collision.gameObject);
                Instantiate(deadAnimation, transform.position, Quaternion.identity);
                audioComponent.Play();
                hide.enabled = false;
                sCollider.enabled = false;
                Invoke("AutoDestroy", 1);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playersLife.TakeDamage(100);
            enemyscore.SubtractPoints(100);
            lifesUI.SubstractLifes(1);
            Instantiate(deadAnimation, transform.position, Quaternion.identity);
            audioComponent.Play();
            hide.enabled = false;
            sCollider.enabled = false;
            Invoke("AutoDestroy", 1);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            hide.enabled = false;
            sCollider.enabled = false;
            Invoke("AutoDestroy", 1);
        }
    }
}
