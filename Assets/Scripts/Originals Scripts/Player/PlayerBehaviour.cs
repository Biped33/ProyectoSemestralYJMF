using UnityEngine;
public class PlayerBehaviour : MonoBehaviour
{
    public float shootDelay = 1f;
    private int playerSpeed = 5;
    private int life = 300;
    public Sprite upShip, normalShip, downShip;
    public GameObject bullet;
    private SpriteRenderer spriteShip;
    private AudioSource audioComponent;
    public Camera mainCamera;

    private void Start()
    {
       FindObjects();
    }

    private void Update()
    {
        PlayerMovement(transform, playerSpeed);
        Shoot();
        CameraRestriccions();
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

    private void Shoot()
    {
        shootDelay -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && shootDelay <= 0)
        {
            Vector3 extraPosition = new Vector3(2, 0, 0);
            audioComponent.Play();
            Instantiate(bullet, transform.position + extraPosition, Quaternion.identity);
            shootDelay = 0.18f;
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

    private void CameraRestriccions()
    {
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        float playerX = transform.position.x;
        float playerY = transform.position.y;
        float clampedX = Mathf.Clamp(playerX, mainCamera.transform.position.x - cameraWidth, mainCamera.transform.position.x + cameraWidth);
        float clampedY = Mathf.Clamp(playerY, mainCamera.transform.position.y - cameraHeight, mainCamera.transform.position.y + cameraHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    private void FindObjects()
    {
        audioComponent = GetComponent<AudioSource>();
        spriteShip = GetComponent<SpriteRenderer>();
    }
}
