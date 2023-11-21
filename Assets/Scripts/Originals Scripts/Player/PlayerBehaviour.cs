using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehaviour : MonoBehaviour
{
    private int playerSpeed = 7;
    private int life = 500;
    private SpriteRenderer spriteShip;
    public Sprite upShip, normalShip, downShip;
    private void Start()
    {
        spriteShip = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        PlayerMovement(transform, playerSpeed);
    }
    private void PlayerMovement(Transform transform, int playerSpeed)
    {
        spriteShip.sprite = normalShip;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            spriteShip.sprite = upShip;
            transform.Translate(Vector3.up.normalized * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            spriteShip.sprite = downShip;
            transform.Translate(Vector3.down.normalized * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right.normalized * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left.normalized * playerSpeed * Time.deltaTime);
        }
    }
    public void TakeDamage(int enemyDamage)
    {
        life -= enemyDamage;
        if (life <= 0)
        {
            WinLoseConditions.instance.LoseCondition();
        }
    }
    public void GainLife(int extralife)
    {
        life += extralife;
    }
    public void AddSpeed(int gainSpeed)
    {
        playerSpeed += gainSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Speed"))
        {
            playerSpeed++;
            Destroy(collision.gameObject);
        }
    }
}
