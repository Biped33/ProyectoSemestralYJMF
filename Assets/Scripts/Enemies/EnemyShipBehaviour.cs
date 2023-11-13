using UnityEngine;

public class EnemyShipBehaviour : MonoBehaviour
{
    //public Animator deadAnimation;
    private ScoreBehaviourLevel2 enemyscore;
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private SpriteRenderer hide;
    private SphereCollider sCollider;
    //private AudioSource audioComponent;
    private int enemySpeed = 10;
    void Start()
    {
        //audioComponent = GetComponent<AudioSource>();
        hide = GetComponent<SpriteRenderer>();
        sCollider = GetComponent<SphereCollider>();
        lifesUI = FindObjectOfType<LifesUIBehaviour>();
        enemyscore = FindObjectOfType<ScoreBehaviourLevel2>();
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
            enemyscore.AddPoints(150);
            Destroy(collision.gameObject);
            //audioComponent.Play();
            //deadAnimation.SetTrigger("dead");
            hide.enabled = false;
            sCollider.enabled = false;
            Invoke("AutoDestroy", 1);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playersLife.TakeDamage(200);
            enemyscore.SubtractPoints(350);
            lifesUI.SubstractLifes(2);
            Destroy(gameObject);
        }
    }
}
