using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehaviour : MonoBehaviour
{
    private int playerSpeed = 10;
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
        if (Input.GetKey(KeyCode.W))
        {
            spriteShip.sprite = upShip;
            transform.Translate(Vector3.up.normalized * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            spriteShip.sprite = downShip;
            transform.Translate(Vector3.down.normalized * playerSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right.normalized * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
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
}
