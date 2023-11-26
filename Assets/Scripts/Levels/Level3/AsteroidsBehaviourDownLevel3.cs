using UnityEngine;

public class AsteroidsBehaviourDownLevel3 : MonoBehaviour
{
    private ScoreBehaviourLevel3 enemyscore;
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private SpriteRenderer hide;
    private SphereCollider sCollider;
    public GameObject deadAnimation;
    private AudioSource explotion;
    private int enemySpeed = 10;
    private Vector3 enemyPatroll = new Vector3(-1, Mathf.Cos(180f), 0);

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
        hide = GetComponent<SpriteRenderer>();
        sCollider = GetComponent<SphereCollider>();
        explotion = GetComponent<AudioSource>();
        lifesUI = FindObjectOfType<LifesUIBehaviour>();
        enemyscore = FindObjectOfType<ScoreBehaviourLevel3>();
        playersLife = FindObjectOfType<PlayerBehaviour>();

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
            Instantiate(deadAnimation, transform.position, Quaternion.identity);
            explotion.Play();
            hide.enabled = false;
            sCollider.enabled = false;
            Invoke("AutoDestroy", 1f);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playersLife.TakeDamage(100);
            enemyscore.SubtractPoints(100);
            lifesUI.SubstractLifes(1);
            Instantiate(deadAnimation, transform.position, Quaternion.identity);
            explotion.Play();
            hide.enabled = false;
            sCollider.enabled = false;
            Invoke("AutoDestroy", 1f);
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
            hide.enabled = false;
            sCollider.enabled = false;
            Invoke("AutoDestroy", 1f);
        }
    }
}
