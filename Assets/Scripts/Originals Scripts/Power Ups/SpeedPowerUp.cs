using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    private PlayerBehaviour playersSpeed;
    private float t, timer = 20f;
    public float r, speed;
    Vector3 position;
    void Start()
    {
        playersSpeed = FindObjectOfType<PlayerBehaviour>();
        position = transform.position;
    }
    void Update()
    {
        transform.position = Path(t);
        FunctionForTime();
        AutoDestroy();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playersSpeed.AddSpeed(3);
            Destroy(gameObject);
        }
    }
    private Vector3 Path(float t)
    {

        float x = r * Mathf.Cos(speed * t) * Mathf.Sin(speed * t);
        float y = r * Mathf.Cos(speed * t);
        float z = 0;
        Vector3 result = new Vector3(x, y, z);
        return result + position;
    }
    private void FunctionForTime()
    {
        t += Time.fixedDeltaTime;
    }

    private void AutoDestroy()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
