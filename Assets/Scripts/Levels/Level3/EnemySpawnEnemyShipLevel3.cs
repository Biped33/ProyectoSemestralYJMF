using UnityEngine;

public class EnemySpawnEnemyShipLevel3: MonoBehaviour
{
    public GameObject enemy1;
    public float randomX;
    public float randomY;
    private float time = 1f;
    void Start()
    {
    }
    void Update()
    {
        SpawnEnemy1();
    }
    private void SpawnEnemy1()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            randomX = Random.Range(12, 15);
            randomY = Random.Range(-4, 4);
            Vector3 enemySpawn = new Vector3(randomX, randomY, 0);
            Instantiate(enemy1, enemySpawn, transform.rotation);
            time = 2f;
        }
    }
}
