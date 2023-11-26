using UnityEngine;

public class ExtraLifePowerUp : MonoBehaviour
{
    private PlayerBehaviour playersLife;
    private LifesUIBehaviour lifesUI;
    private float t, timer = 15f;
    public float r, speed;
    Vector3 position;
    void Start()
    {
        playersLife = FindObjectOfType<PlayerBehaviour>();
        lifesUI = FindObjectOfType<LifesUIBehaviour>();
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
            playersLife.GainLife(100);
            lifesUI.AddLifes(1);
            Destroy(gameObject);
        }
    }
    private Vector3 Path(float t)
    {
        float x = -speed * t;
        float y = r * Mathf.Cos(speed * t) * Mathf.Sin(speed * t);
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
