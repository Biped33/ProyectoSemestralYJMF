using UnityEngine;
public class MegaAsteroidBehaviour : MonoBehaviour
{
    private ScoreBehaviourLevel3 enemyscore;
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private SpriteRenderer hide;
    private SphereCollider sCollider;
    private AudioSource audioComponent;
    private int enemySpeed = 5;
    private int asteroidLife = 700;
    private int numberOfAsteroids = 3;
    public GameObject[] miniAsteroids;
    public GameObject deadAnimation;

    void Start()
    {
        FindObjects();
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

    private void TakeDamage(int bulletDamage)
    {
        asteroidLife -= bulletDamage;
    }

    private void FindObjects()
    {
        audioComponent = GetComponent<AudioSource>();
        hide = GetComponent<SpriteRenderer>();
        sCollider = GetComponent<SphereCollider>();
        lifesUI = FindObjectOfType<LifesUIBehaviour>();
        enemyscore = FindObjectOfType<ScoreBehaviourLevel3>();
        playersLife = FindObjectOfType<PlayerBehaviour>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            TakeDamage(100);
            Destroy(collision.gameObject);
            if (asteroidLife <= 0)
            {
                enemyscore.AddPoints(500);
                Destroy(collision.gameObject);
                Instantiate(deadAnimation, transform.position, Quaternion.identity);
                audioComponent.Play();
                hide.enabled = false;
                sCollider.enabled = false;
                for (var i = 0; i < numberOfAsteroids; i++)
                {
                    Instantiate(miniAsteroids[Random.Range(0, miniAsteroids.Length)], transform.position, Quaternion.identity);
                }
                Invoke("AutoDestroy", 1);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playersLife.TakeDamage(300);
            enemyscore.SubtractPoints(450);
            lifesUI.SubstractLifes(3);
            Instantiate(deadAnimation, transform.position, Quaternion.identity);
            audioComponent.Play();
            hide.enabled = false;
            sCollider.enabled = false;
            for (var i = 0; i < numberOfAsteroids; i++)
            {
                Instantiate(miniAsteroids[Random.Range(0, miniAsteroids.Length)], transform.position, Quaternion.identity);
            }
            Invoke("AutoDestroy", 1);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}