using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    float time = 1f;
    public float randomX;
    public float randomY;
    void Start()
    {


    }


    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            randomX = Random.Range(12, 15);
            randomY = Random.Range(-4, 4);
            Vector3 enemySpawn = new Vector3(randomX, randomY, 0);
            Instantiate(enemy, enemySpawn, transform.rotation);
            time = 1f;
        }
    }
}
