using UnityEngine;

public class EnemyShipShootingBehaviour : MonoBehaviour
{ 
    private ScoreBehaviourLevel2 enemyscore;
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private SpriteRenderer hide;
    private SphereCollider sCollider;
    public GameObject bullet, deadAnimation;
    public AudioSource audioComponentShoot, dead;
    private int lifeEnemyShip = 500;
    private int enemySpeed = 5;
    private float shootDelay = 1f;

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

    private void Shoot()
    {
        shootDelay -= Time.deltaTime;
        if (shootDelay <= 0 && lifeEnemyShip > 0)
        {
            Vector3 extraPosition = new Vector3(-2.5f, 0, 0);
            audioComponentShoot.Play();
            Instantiate(bullet, transform.position + extraPosition, Quaternion.Euler(180,0,-180));
            shootDelay = 1.5f;
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
                enemyscore.AddPoints(200);
                Destroy(collision.gameObject);
                Instantiate(deadAnimation, transform.position, Quaternion.identity);
                dead.Play();
                hide.enabled = false;
                sCollider.enabled = false;
                Invoke("AutoDestroy", 1);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playersLife.TakeDamage(300);
            enemyscore.SubtractPoints(350);
            lifesUI.SubstractLifes(3);
            dead.Play();
            hide.enabled = false;
            sCollider.enabled = false;
            Invoke("AutoDestroy", 1);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            hide.enabled = false;
            sCollider.enabled = false;
            Invoke("AutoDestroy", 1);
            audioComponentShoot.enabled = false;
        }
    }
}
